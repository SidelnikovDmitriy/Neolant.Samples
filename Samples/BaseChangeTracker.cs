using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Samples.Abstract.Classes;
using Samples.AbstractBase.Interfaces;

namespace Samples
{
    /// <summary>
    /// Отслеживание изменения объектов
    /// </summary>
    public abstract class BaseChangeTracker : Base , IChangeTracker
    {
        /// <summary>
        /// Флаг допустимости отслеживания изменений
        /// </summary>
        private bool mTrackChanges;
        /// <summary>
        /// Состояния объекта
        /// </summary>
        public Dictionary<string, object> Changes { get; private set; }

        /// <summary>
        /// Сообщает об изменениях словаря изменений
        /// </summary>
        public event EventHandler<IChangeTrackerObject> ChangesChanged;

        /// <summary>
        /// Флаг повествует о наличии изменений
        /// </summary>
        public virtual bool IsDirty
        {
            get { return Changes.Count > 0; }
        }


        /// <summary>
        /// Ctor
        /// </summary>
        protected BaseChangeTracker()
        {
            //по умолячанию отслеживаем
            mTrackChanges = true;
            //словарь изменений
            Changes = new Dictionary<string, object>();
        }

        /// <summary>
        /// Сброс изменений
        /// </summary>
        public void ResetChanges()
        {
            Changes.Clear();
            RaiseChangesChanged(new ChangesStateEventArgs(Changes));
        }
        /// <summary>
        /// Запуск отслеживания
        /// изменений
        /// </summary>
        public void StartTracking()
        {
            mTrackChanges = true;
        }
        /// <summary>
        /// Остановка отслеживания
        /// </summary>
        public void StopTracking()
        {
            mTrackChanges = false;
        }

        /// <summary>
        /// Сообщаем о том, что свойство
        /// изменилось 
        /// </summary>
        /// <typeparam name="T">Тип класса, содержащего свойство</typeparam>
        /// <typeparam name="F">Тип поля и значения</typeparam>
        /// <param name="field">Поле</param>
        /// <param name="property">Свойство</param>
        /// <param name="value">Новое значение</param>
        public void ApplyPropertyChange<T, F>(ref F field, Expression<Func<T, object>> property, F value)
        {
            // если есть поле, и оно реально изменилось
            if (field == null || !field.Equals(value))
            {

                // получение члена выражения
                var propertyExpression = GetMemberExpression(property);

                if (propertyExpression == null)
                    throw new InvalidOperationException("Необходимо определить свойство");

                // Цепляем имя, можно использовать перегрузку с propertyName
                string propertyName = propertyExpression.Member.Name;

                //задаем новое значение
                field = value;

                // Если разрешено отслеживание изменений
                if (mTrackChanges)
                {
                    // Логируем изменяемое свойство 
                    OnHasChanges(propertyName, value);
                    // сообщаем например View о его изменении
                    OnPropertyChanged(propertyName);
                }
            }
        }
        /// <summary> 
        /// Сообщаем о том, что свойство 
        /// изменилось, перегрузка без разбора выражения
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="F"></typeparam>
        /// <param name="field"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public void ApplyPropertyChange<T, F>(ref F field, string propertyName, F value)
        {
            // если есть поле, и оно реально изменилось
            if (field == null || !field.Equals(value))
            {
                //задаем новое значение
                field = value;

                // Если разрешено отслеживание изменений
                if (mTrackChanges)
                {
                    // Логируем изменяемое свойство 
                    OnHasChanges(propertyName, value);
                    // сообщаем, например View, о его изменении
                    OnPropertyChanged(propertyName);
                }
            }
        }

        /// <summary>
        /// Для ObservableCollection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="F"></typeparam>
        /// <param name="field"></param>
        /// <param name="property"></param>
        /// <param name="value"></param>
        public void ApplyCollectionChange<T, F>(ref ObservableCollection<F> field, Expression<Func<T, object>> property, ObservableCollection<F> value)
            where F : BaseChangeTracker
        {
            //если присваиваем
            ApplyPropertyChange(ref field, property, value);

            // Цепляем имя
            string propertyName = GetMemberExpression(property).Member.Name;
           
            //берем каждый элемент коллекции и  подписываем его на отслеживание изменений
            foreach (var item in value)
            {
                SubcribeCollectionItem(item, propertyName, value);
            }

            //подписываемся на измениение коллекции (add/remove/...)
            value.CollectionChanged += (sender, args) =>
            {
                var values = (ObservableCollection<F>)sender;

                switch (args.Action)
                {
                    //Если тип изменения добавление элемента -> подписываем его на отслеживание изменений
                    case NotifyCollectionChangedAction.Add:
                        foreach (var item in args.NewItems.Cast<F>())
                        {
                            SubcribeCollectionItem(item, propertyName, values);
                        }
                        break;
                        // отдельная обработка для разных случев
                        // ...
                        // пока нет необходимости
                }
                OnHasChanges(propertyName, values);
            };
        }

        /// <summary>
        /// Подписываем элемент коллекции на изменения
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="item">объект наследующий трасировщика изменений</param>
        /// <param name="collectionName">имя коллекции</param>
        /// <param name="collectionValues"></param>
        private void SubcribeCollectionItem<T>(BaseChangeTracker item, string collectionName, T collectionValues)
        {
            item.ChangesChanged += (o, eventArgs) =>
            {
                if (eventArgs.IsDirty)
                    OnHasChanges(collectionName, collectionValues);
            };
        }
        /// <summary>
        /// Устанавливает изменения значений указанного свойства
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public void OnHasChanges<T>(string propertyName, T value)
        {
            Changes[propertyName] = value;
            // Notify change
            OnPropertyChanged(propertyName);

            RaiseChangesChanged(new ChangesStateEventArgs(Changes));
        }

        /// <summary>
        /// Удаляет изменения определенного свойства
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property"></param>
        protected void RemovePropertyChanges<T>(Expression<Func<T, object>> property)
        {
            string propertyName = GetMemberExpression(property).Member.Name;
            Changes.Remove(propertyName);
        }


        /// <summary>
        /// Получение члена выражения
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public MemberExpression GetMemberExpression<T>(Expression<Func<T,
                                object>> expression)
        {

            MemberExpression memberExpression = null;

            if (expression.Body.NodeType == ExpressionType.Convert)
            {
                var body = (UnaryExpression)expression.Body;
                memberExpression = body.Operand as MemberExpression;
            }

            else if (expression.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpression = expression.Body as MemberExpression;
            }

            if (memberExpression == null)
                throw new ArgumentException("Not a member access",
                                            "expression");

            return memberExpression;
        }

        /// <summary>
        /// Запись наших измененеий в XML
        /// (фича, если нужно)
        /// </summary>
        /// <returns></returns>
        public XDocument ChangesToXml()
        {
            // декларация, заголовок XML
            XDeclaration declaration = new XDeclaration("1.0",
                                           Encoding.UTF8.HeaderName, String.Empty);
            // корневой элемент
            XElement root = new XElement("Changes");
            // Инициирую документ XML
            XDocument document = new XDocument(declaration, root);
            //Записываем формирую XML
            foreach (KeyValuePair<string, object> change in Changes)
                root.Add(new XElement(change.Key, change.Value));
            //готовый документ XML
            return document.Document;
        }

        /// <summary>
        /// Сообщаем об изменении состояния
        /// </summary>
        /// <param name="e"></param>
        private void RaiseChangesChanged(ChangesStateEventArgs e)
        {
            EventHandler<IChangeTrackerObject> handler = ChangesChanged;
            if (handler != null)
                ChangesChanged(this, e);
        }


    }


    /// <summary>
    /// Класс аргументов события произошедших изменений в словаре изменений
    /// </summary>
    public class ChangesStateEventArgs : EventArgs, IChangeTrackerObject

    {
        /// <summary>
        /// Есть ли изменения
        /// </summary>
        public bool IsDirty
        {
            get { return Changes.Count > 0; }
        }

        /// <summary>
        /// Словарь изменений
        /// </summary>
        public Dictionary<string, object> Changes { get; private set; }

        /// <summary>
        /// Состояние объекта изменилось
        /// </summary>
        /// <param name="changes"></param>
        public ChangesStateEventArgs(Dictionary<string, object> changes)
        {
            Changes = changes;
        }

    }
}
