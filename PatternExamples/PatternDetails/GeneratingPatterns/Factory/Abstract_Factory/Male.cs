namespace Pattern.Details
{
    /// <summary>
    /// Мужчина
    /// </summary>
    public abstract class Male : Human
    {
        /// <summary>
        /// Константа обозначающая мужчину
        /// </summary>
        public const string cMale = "man";
        /// <summary>
        /// Описание
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        protected override string GetDescription(string description = null)
        {
            return description == null ? cMale : string.Format("{0} and i {1}!", cMale, description) ;
        }
    }
}
