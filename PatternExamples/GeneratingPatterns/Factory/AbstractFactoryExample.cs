using System;
using System.Collections.Generic;
using System.Text;
using Common.Extenssions;
using Pattern.Details;
using Common;

namespace Examples.Patterns
{

    public class AbstractFactoryExample : BaseExample
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public AbstractFactoryExample():
            base("Абстрактная фабрика", "Порождающие паттерны")
        {
        }
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
                new AfricanFactory()
            };

            var all = GetAllHumans(factories);

            foreach (var human in all)
                AskForHuman(human);
            
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
    class AfricanFactory : HumanFactory
    {
        /// <summary>
        /// Создет женщину
        /// </summary>
        /// <returns></returns>
        public override Female MakeFemale()
        {
            return new AfricanFemale();
        }
        /// <summary>
        /// Создет мужика
        /// </summary>
        /// <returns></returns>
        public override Male MakeMale()
        {
            return new AfricanMale();
        }

    }




}
