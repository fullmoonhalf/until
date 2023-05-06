namespace until.test3
{
    public enum LocatorRange
    {
        InRange,
        OutRange,
    }

    public abstract class Locator
    {
        #region Definition
        public abstract LocatorRange checkRange(Locator locator);
        #endregion

        #region Properties
        public int Area { get; private set; }
        #endregion

        #region Fields
        public Locator(int area)
        {
            Area = area;
        }
        #endregion

        #region Methods
        #endregion

        #region Develop
#if TEST
        public virtual string DevelopExpression
        {
            get => $"{GetType().Name}";
        }
#endif
        #endregion
    }
}
