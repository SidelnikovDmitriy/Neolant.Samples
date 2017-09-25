using System;
using System.Collections.Generic;
using Common;
using Common.Abstract;
using System.Linq;

namespace Samples.Menu
{
    public class MenuConstructor : IMenuConstructor
    {
        public IMenu ConstructMenu(IMenuItemsLoader items)
        {
            var menu = new Dictionary<int, BaseExample>();

            var menuItems = items.GetMenuItems().ToArray();

            for (int i = 0; i < menuItems.Count(); ++i)
                menu.Add(i+1, menuItems[i]);

            return new MenuModel(menu);
        }
    }
}
