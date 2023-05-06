using System.Collections.Generic;


namespace until.test3
{
    public abstract class LocationAreaControl
    {
        #region Definition
        public abstract Locator[] extractLocation(LocatorRange range);
        #endregion

        #region Properties
        static protected Locator[] EMPTY_LOCAION_LIST { get; private set; } = new Locator[0];
        public int Area { get; private set; }
        #endregion

        #region Fields
        #endregion

        #region Methods
        public LocationAreaControl(int area)
        {
            Area = area;
        }
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
