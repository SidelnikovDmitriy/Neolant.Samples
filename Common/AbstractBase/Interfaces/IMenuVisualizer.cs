
namespace Common.Abstract
{
    public interface IMenuVisualizer<T> : IMenuVisualizer
    {
        new T ShowMenu(IMenu menucreator);
    }

    public interface IMenuVisualizer
    {
        void ShowMenu(IMenu menu);
    }
}
