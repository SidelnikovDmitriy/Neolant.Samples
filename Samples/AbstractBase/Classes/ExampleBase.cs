using Samples.Abstract.Classes;

namespace Samples.AbstractBase.Classes
{
    public abstract class ExampleBase : Base
    {

        protected ExampleBase(string name)
        {
            DisplayName = name;
        }

        public abstract void Run();

    }
}
