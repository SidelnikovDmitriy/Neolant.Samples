using Common;
using System;
using System.Collections.Generic;

namespace Examples.PatternDetails
{
    #region Interfaces
    /// <summary>
    ///  Считыватель модели телефона
    /// </summary>
    public interface IPhoneReader
    {
        string[] GetInputData();
    }
    /// <summary>
    /// Выполняет привязку модели
    /// </summary>
    public interface IPhoneBinder
    {
        Phone CreatePhone(string[] data);
    }
    /// <summary>
    /// Проверка введенных данных
    /// </summary>
    public interface IPhoneValidator
    {
        bool IsValid(Phone phone);
    }
    /// <summary>
    /// Сохранение данных
    /// </summary>
    public interface IPhoneSaver
    {
        void Save(Phone phone);
    }
    #endregion

    #region Model
    /// <summary>
    /// Телефон
    /// </summary>
    public class Phone
    {
        public string Model { get; set; }
        public int Price { get; set; }
    }
    #endregion

    #region Implements
    /// <summary>
    /// Считывает сведения о телефоне
    /// </summary>
    class ConsolePhoneReader : IPhoneReader
    {
        public string[] GetInputData()
        {
            Console.WriteLine("Введите модель:");
            string model = Console.ReadLine();
            Console.WriteLine("Введите цену:");
            string price = Console.ReadLine();
            return new string[] { model, price };
        }
    }
    /// <summary>
    /// Осуществляет привязку
    /// введенных данных, к созданному телефону
    /// </summary>
    class GeneralPhoneBinder : IPhoneBinder
    {
        public Phone CreatePhone(string[] data)
        {
            if (data.Length >= 2)
            {
                int price = 0;
                if (Int32.TryParse(data[1], out price))
                {
                    return new Phone { Model = data[0], Price = price };
                }
                else
                {
                    throw new Exception("Ошибка привязчика модели Phone. Некорректные данные для свойства Price");
                }
            }
            else
            {
                throw new Exception("Ошибка привязчика модели Phone. Недостаточно данных для создания модели");
            }
        }
    }
    /// <summary>
    /// Валидация
    /// </summary>
    class GeneralPhoneValidator : IPhoneValidator
    {
        public bool IsValid(Phone phone)
        {
            if (String.IsNullOrEmpty(phone.Model) || phone.Price <= 0)
                return false;

            return true;
        }
    }
    /// <summary>
    /// Запись полученных данных в файл
    /// </summary>
    class TextPhoneSaver : IPhoneSaver
    {
        public void Save(Phone phone)
        {
            Console.WriteLine("Запись сведений о телефоне: {0}.", phone.Model);
        }
    }

    #endregion
    /// <summary>
    /// Расширенный пример использования приципа единственной обязанности
    /// </summary>
    public class MobileStore
    {
        List<Phone> phones = new List<Phone>();

        public IPhoneReader Reader { get; set; }
        public IPhoneBinder Binder { get; set; }
        public IPhoneValidator Validator { get; set; }

        public IPhoneSaver Saver { get; set; }

        public MobileStore(IPhoneReader reader, IPhoneBinder binder, IPhoneValidator validator, IPhoneSaver saver)
        {
            Reader = reader;
            Binder = binder;
            Validator = validator;
            Saver = saver;
        }

        public void Process()
        {
            string[] data = Reader.GetInputData();
            Phone phone = Binder.CreatePhone(data);
            if (Validator.IsValid(phone))
            {
                phones.Add(phone);
                Saver.Save(phone);
                Console.WriteLine("Данные успешно обработаны");
            }
            else
            {
                Console.WriteLine("Некорректные данные");
            }
        }
    }

    public class SingleResponsibilityEx : BaseExample
    {

        public SingleResponsibilityEx() : base("(S) Расширенный пример Single Responsibility", "SOLID Principles")
        {

        }

        public override void Run()
        {
            var store = new MobileStore(new ConsolePhoneReader(),
                new GeneralPhoneBinder(),
                new GeneralPhoneValidator(),
                new TextPhoneSaver());

            try
            {
                store.Process();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Возникла ошибка:{0}...", ex.Message);
            }
        }
    }


}
