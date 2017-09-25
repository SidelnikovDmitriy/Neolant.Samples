using System;
using System.Collections.Generic;
using Common;
using Common.Abstract;

namespace Samples.Menu
{
    public class MenuModel : IMenu
    {
        /// <summary>
        /// Данные меню
        /// </summary>
        public IDictionary<int, BaseExample> MenuData { get; private set; }
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="mMenuData"></param>
        public MenuModel(IDictionary<int, BaseExample> mMenuData)
        {
            MenuData = mMenuData;
        }
        /// <summary>
        /// Выбор пункта меню
        /// </summary>
        /// <param name="number"></param>
        public void SelectItem(int number)
        {
            if (MenuData.ContainsKey(number))
                MenuData[number].Run();
        }
    }
}
