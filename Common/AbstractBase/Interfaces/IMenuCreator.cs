using System.Collections.Generic;

namespace Common.Abstract
{
    public interface IMenuConstructor
    {
        /// <summary>
        /// Построитель меню
        /// </summary>
        /// <returns></returns>
        IMenu ConstructMenu(IMenuItemsLoader items);
    }
}
