using System.Collections.Generic;

namespace Common.Abstract
{
    public interface IMenu
    {
        IDictionary<int, BaseExample> MenuData { get; }

        void SelectItem(int number);

    }
}
