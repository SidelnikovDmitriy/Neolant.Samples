namespace Samples.Factory.Abstract_Factory
{
    public abstract class Female : Human
    {
        public const string cFemale = "Woman";

        protected override string GetDescription(string description = null)
        {

            return description == null ? cFemale : string.Format("{0} and i {1}!", cFemale, description);
        }
    }
}
