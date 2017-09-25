using Common.Abstract;

namespace Pattern.Details
{
    /// <summary>
    /// Абстрактный класс, определяющий фабричный метод 
    /// Create();
    /// </summary>
    public abstract class CarFactory
    {
        /// <summary>
        /// Фабричный метод
        /// </summary>
        /// <returns></returns>
        public abstract ICar Create();

    }
}
