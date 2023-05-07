namespace until.test3
{
    public class PseudoMobileLocator : Locator
    {
        #region Definition
        #endregion

        #region Properties
        #endregion

        #region Fields
        #endregion

        #region Methods
        public PseudoMobileLocator(int area)
            : base(area)
        {
        }

        #region Locator
        public override LocatorRange checkRange(Locator locator)
        {
            return LocatorRange.OutRange;
        }
        #endregion
        #endregion

        #region Develop
#if TEST
        public override string DevelopExpression
        {
            get => $"{GetType().Name}";
        }

#endif
        #endregion
    }
}
