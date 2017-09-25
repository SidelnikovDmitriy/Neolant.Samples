using Common.Abstract;
using Samples.Menu;

namespace Samples
{
    public class StartExample
    {
        /// <summary>
        /// Главное меню
        /// </summary>
        private static IMenuOperator mMenuOpertor;

        /// <summary>
        /// Точка входа
        /// </summary>
        static void Main()
        {
            mMenuOpertor = mMenuOpertor ?? new MenuOperator(new MenuLoader(),new MenuConstructor(), new MenuVisulizer());
            mMenuOpertor.BuildMenu();
            mMenuOpertor.ShowMenu();
            Main();
        }
        

      
    }
}
