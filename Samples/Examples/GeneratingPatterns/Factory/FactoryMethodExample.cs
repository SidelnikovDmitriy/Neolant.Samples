using Samples.AbstractBase.Interfaces;
using System;

namespace Samples.Factory
{
    public class FactoryMethodExample
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="factory"></param>
        FactoryMethodExample(CarFactory factory)
        {
            var car = GetCar(factory);
            ShowMyCar(car);
        }
        /// <summary>
        /// Default:ctor
        /// </summary>
        public FactoryMethodExample() : 
            this(CarFactoryGenerator.GetRandomFactory())
        {
        }
        
        /// <summary>
        /// Возвращает тачку
        /// </summary>
        /// <returns></returns>
        ICar GetCar(CarFactory factory)
        {
            return factory.Create();
        }
        /// <summary>
        /// Понтануться тачкой
        /// </summary>
        /// <param name="myCar"></param>
        void ShowMyCar(ICar myCar)
        {
            Console.WriteLine(string.Format("Моя тачка: {0}! А чего добился ты, щен ?", myCar.Name));
        }


    }

    /// <summary>
    /// Завод А
    /// </summary>
    class PorscheAutomobilHolding : CarFactory
    {
        public override ICar Create()
        {
            return new GoodCar();
        }
    }

    /// <summary>
    /// Завод Б
    /// </summary>
    class AutoVaz : CarFactory
    {
        public override ICar Create()
        {
            return new YourCar();
        }
    }


    /// <summary>
    /// Авто завода А
    /// </summary>
    class GoodCar : ICar
    {
        /// <summary>
        /// Имя автомобиля
        /// </summary>
        public string Name
        {
            get
            {
                return "Porsche Cayman 718";
            }
        }
    }
    /// <summary>
    /// Авто завода Б
    /// </summary>
    class YourCar : ICar
    {
        /// <summary>
        /// Имя автомобиля
        /// </summary>
        public string Name
        {
            get
            {
                return "LADA Priora (2170)";
            }
        }
    }

    #region Abstract

   

   
    #endregion


}
