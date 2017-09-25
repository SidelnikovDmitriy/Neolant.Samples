using Common.Abstract;

namespace Common
{
    public abstract class BaseExample : Base
    {

        public string Group { get; set; }

        protected BaseExample(string name)
        {
            DisplayName = name;
        }
        protected BaseExample(string name, string groupename = null) : this(name)
        {
            Group = groupename;
        }

        public abstract void Run();

    }
}
