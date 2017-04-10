using Samples.AbstractBase.Interfaces;

namespace Samples.Factory
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
