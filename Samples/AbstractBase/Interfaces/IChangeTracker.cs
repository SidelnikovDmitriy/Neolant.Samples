using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace Samples.AbstractBase.Interfaces
{
    public interface IChangeTracker : IChangeTrackerObject
    {
        /// <summary>
        /// Сброс изменений
        /// </summary>
        void ResetChanges();
        /// <summary>
        /// Начало отслеживания изменений
        /// </summary>
        void StartTracking();
        /// <summary>
        /// Остановка отслеживания
        /// </summary>
        void StopTracking();
        /// <summary>
        /// Сообщаем об изменении свойства
        /// </summary>
        void ApplyPropertyChange<T, F>(ref F field, Expression<Func<T, object>> property, F value);
        /// <summary>
        /// Сообщаем об изменении свойства
        /// </summary>
        void ApplyPropertyChange<T, F>(ref F field, string propertyName, F value);
        /// <summary>
        /// Сообщаем об изменении коллекции
        /// </summary>
        void ApplyCollectionChange<T, F>(ref ObservableCollection<F> field, Expression<Func<T, object>> property, ObservableCollection<F> value) 
            where F : BaseChangeTracker;
        /// <summary>
        /// Действия по наличию изменений
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        void OnHasChanges<T>(string propertyName, T value);

    }

    public interface IChangeTrackerObject
    {
        /// <summary>
        /// Флаг сообщающий о наличие изменений
        /// </summary>
        bool IsDirty { get; }
        /// <summary>
        /// Словарь изменений
        /// </summary>
        Dictionary<string, object> Changes { get; }
    }
}
