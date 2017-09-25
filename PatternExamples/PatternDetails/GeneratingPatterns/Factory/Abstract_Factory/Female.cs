namespace Pattern.Details
{
    /// <summary>
    /// Женщина
    /// </summary>
    public abstract class Female : Human
    {
        /// <summary>
        /// Константа обозначающая женщину
        /// </summary>
        public const string cFemale = "woman";
        /// <summary>
        /// Описание
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        protected override string GetDescription(string description = null)
        {

            return description == null ? cFemale : string.Format("{0} and i {1}!", cFemale, description);
        }
    }
}
