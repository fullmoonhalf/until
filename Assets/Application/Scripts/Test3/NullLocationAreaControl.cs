namespace until.test3
{
    public class NullLocationAreaControl : LocationAreaControl
    {
        #region Definition
        #endregion

        #region Properties
        #endregion

        #region Fields
        #endregion

        #region Methods
        public NullLocationAreaControl(int area)
            : base(area)
        {
        }

        #region LocationAreaControl
        public override Locator[] extractLocation(LocatorRange range)
        {
            return EMPTY_LOCAION_LIST;
        }
        #endregion
        #endregion
    }
}
