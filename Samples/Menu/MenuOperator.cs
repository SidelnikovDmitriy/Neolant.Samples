using Common.Abstract;

namespace Samples.Menu
{
    public class MenuOperator : IMenuOperator
    {
        /// <summary>
        /// Данные меню
        /// </summary>
        private IMenuItemsLoader mItems;
        /// <summary>
        /// Построение меню
        /// </summary>
        private IMenuConstructor mMenuConstructor;
        /// <summary>
        /// Визуализация меню
        /// </summary>
        private IMenuVisualizer mMenuVisualizer;

        /// <summary>
        /// Меню
        /// </summary>
        private IMenu mMenu;
        
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="itemsLoader"></param>
        /// <param name="menuConstructor"></param>
        /// <param name="visualizer"></param>
        public MenuOperator(IMenuItemsLoader itemsLoader, IMenuConstructor menuConstructor, IMenuVisualizer visualizer)
        {
            mItems = itemsLoader;
            mMenuConstructor = menuConstructor;
            mMenuVisualizer = visualizer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IMenu IMenuOperator.BuildMenu()
        {
            mMenu = mMenuConstructor.ConstructMenu(mItems);
            return mMenu;
        }

        public void ShowMenu()
        {
            mMenuVisualizer.ShowMenu(mMenu);
        }
    }

}
