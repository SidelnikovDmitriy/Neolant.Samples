using Common.Abstract;

namespace Common.Abstract
{
    public interface IMenuOperator
    {
        IMenu BuildMenu();

        void ShowMenu();
    }
}
