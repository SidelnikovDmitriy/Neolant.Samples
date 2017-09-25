using Common.Abstract;
using System;
using System.Collections.Generic;

namespace Samples.Menu
{
    public class MenuVisulizer : IMenuVisualizer
    {
        private IMenu mMenu;

        public void ShowMenu(IMenu menuModel)
        {
            Console.Clear();

            Console.WriteLine("Примеры:");

            mMenu = mMenu ?? menuModel;

            var groups = new HashSet<string>();

            foreach (var menu in mMenu.MenuData)
            {
                var group = menu.Value.Group;
                if (group != null && !groups.Contains(group))
                {
                    Console.WriteLine();
                    Console.WriteLine(">>> {0}: ", menu.Value.Group);
                    groups.Add(group);
                }

                Console.WriteLine("№{0}. {1}", menu.Key, menu.Value.DisplayName);
            }



            Console.WriteLine("----------------------");
            Console.WriteLine("Введите номер примера:");

            var baseValue = Console.ReadLine().Trim();


            int selectValue = 0;

            var correct = int.TryParse(baseValue, out selectValue);


            if (!correct || !mMenu.MenuData.ContainsKey(selectValue))
                ShowMenu(menuModel);

            Console.Clear();

            Console.WriteLine(">Выполняю:");

            mMenu.SelectItem(selectValue);

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Нажмите <Enter> чтобы вернуться в меню...");
            Console.ReadLine();
        }
    }
}
