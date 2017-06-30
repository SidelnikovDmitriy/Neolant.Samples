using Samples.AbstractBase.Classes;
using Samples.Examples.Builder;
using Samples.Examples.Factory;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Samples
{
    public class StartExample
    {
        /// <summary>
        /// Главное меню
        /// </summary>
        private static IDictionary<byte, ExampleBase> mMenu;

        /// <summary>
        /// Точка входа
        /// </summary>
        static void Main()
        {
            SetMainMenu();
            ShowMenu();
            Main();
        }

        /// <summary>
        /// Инициализирует меню
        /// </summary>
        private static void SetMainMenu()
        {
            mMenu = mMenu ?? new Dictionary<byte, ExampleBase>
            {
                {1 , new AbstractFactoryExample() },
                {2 , new BuilderExample() }
            };
        }

        /// <summary>
        /// Показывает меню
        /// </summary>
        private static void ShowMenu()
        {
            Console.Clear();

            Console.WriteLine("Примеры:");

            foreach (var menu in mMenu)
                Console.WriteLine(string.Format("№{0}. {1}", menu.Key, menu.Value.DisplayName));

            Console.WriteLine("----------------------");
            Console.WriteLine("Введите номер примера:");

            var baseValue = Console.ReadLine().Trim();


            byte byteValue = 0;

            var correct = byte.TryParse(baseValue, out byteValue);


            if (!correct || !mMenu.ContainsKey(byteValue))
                ShowMenu();


            Console.Clear();

            Console.WriteLine(">Выполняю:");

            ExecuteExample(byteValue);

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Нажмите <Enter> чтобы вернуться в меню...");
            Console.ReadLine();
        }
        /// <summary>
        /// Выполняем пример
        /// </summary>
        /// <param name="number"></param>
        private static void ExecuteExample(byte number)
        {
            if (mMenu.ContainsKey(number))
                mMenu[number].Run();
        }

    }
}
