using System;
using Samples.Factory.Abstract_Factory;
using Samples.Factory.Abstract_Factory.Humans;
using System.Collections.Generic;
using Samples.AbstractBase.Classes;
using Samples.Extenssions;
using System.Text;

namespace Samples.Examples.Factory
{

    public class AbstractFactoryExample : ExampleBase
    {
        /// <summary>
        /// Запуск примера
        /// </summary>
        public override void Run()
        {

            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            var factories = new List<HumanFactory>()
            {
                new EuropeanFactory(),
                new AsianFactory(),
                new NiggerFactory()
            };

            var all = GetAllHumans(factories);

            foreach (var human in all)
                AskForHuman(human);

         

            Console.ReadLine();
        }
        /// <summary>
        /// Возращает коллекцию людей
        /// </summary>
        /// <param name="factories"></param>
        /// <returns></returns>
        private IEnumerable<Human> GetAllHumans(IEnumerable<HumanFactory> factories)
        {
            var all = new List<Human>();

            foreach (var factory in factories)
            {
                all.AddRange(CreateHumans(factory));
            }

            return all.Randomize();
        }
        /// <summary>
        /// Создает коллекцию из 5 человек
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        private IEnumerable<Human> CreateHumans(HumanFactory factory)
        {
            for (int i = 0; i < 5; i++)
            {
                yield return factory.GetRandom();
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
