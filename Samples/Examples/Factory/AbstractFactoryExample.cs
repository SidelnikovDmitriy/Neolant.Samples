using System;
using Samples.Factory.Abstract_Factory;
using Samples.Factory.Abstract_Factory.Humans;
using System.Collections.Generic;
using Samples.AbstractBase.Classes;

namespace Samples.Examples.Factory
{
    public class AbstractFactoryExample : ExampleBase
    {
        /// <summary>
        /// Запуск примера
        /// </summary>
        public override void Run()
        {
            var factories = new List<HumanFactory>()
            {
                new EuropeanFactory(),
                new AsianFactory(),
                new NiggerFactory()
            };

            foreach (var factory in factories)
            {
                Human human = factory.GetRandom();
                AskForHuman(human);
            }
        }

        /// <summary>
        /// Пусть пояснит
        /// </summary>
        /// <param name="human"></param>
        private void AskForHuman(Human human)
        {
            Console.WriteLine(human.WhoAreYoure());
        }

    }
    /// <summary>
    /// Европейцы
    /// </summary>
    class EuropeanFactory : HumanFactory
    {
        /// <summary>
        /// Создет женщину
        /// </summary>
        /// <returns></returns>
        public override Female MakeFemale()
        {
            return new EuropeanFemale();
        }
        /// <summary>
        /// Создет мужика
        /// </summary>
        /// <returns></returns>
        public override Male MakeMale()
        {
            return new EuropeanMale();
        }
    }
    /// <summary>
    /// Азиаты
    /// </summary>
    class AsianFactory : HumanFactory
    {
        /// <summary>
        /// Создет женщину
        /// </summary>
        /// <returns></returns>
        public override Female MakeFemale()
        {
            return new AsianFemale();
        }
        /// <summary>
        /// Создет мужика
        /// </summary>
        /// <returns></returns>
        public override Male MakeMale()
        {
            return new AsianMale();
        }
    }
    /// <summary>
    /// Европейцы
    /// </summary>
    class NiggerFactory : HumanFactory
    {
        /// <summary>
        /// Создет женщину
        /// </summary>
        /// <returns></returns>
        public override Female MakeFemale()
        {
            return new NiggerFemale();
        }
        /// <summary>
        /// Создет мужика
        /// </summary>
        /// <returns></returns>
        public override Male MakeMale()
        {
            return new NiggerMale();
        }

    }




}
