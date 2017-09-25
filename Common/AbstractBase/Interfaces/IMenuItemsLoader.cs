using System.Collections.Generic;

namespace Common.Abstract
{
    /// <summary>
    /// Загрузчик пунктов меню
    /// </summary>
    public interface IMenuItemsLoader
    {
        /// <summary>
        /// Возвращает данны для отображения меню
        /// </summary>
        /// <returns></returns>
        IEnumerable<BaseExample> GetMenuItems();

    }
}
