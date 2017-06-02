namespace Samples.Factory.Abstract_Factory
{
    public abstract class Male : Human
    {
        public const string cMale = "man";
        
        protected override string GetDescription(string description = null)
        {
            return description == null ? cMale : string.Format("{0} and i {1}!", cMale, description) ;
        }
    }
}
