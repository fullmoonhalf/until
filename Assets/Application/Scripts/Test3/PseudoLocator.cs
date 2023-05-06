namespace until.test3
{
    public class PseudoLocator : Locator
    {
        #region Definition
        #endregion

        #region Properties
        #endregion

        #region Fields
        private int _ID = 0;
        #endregion

        #region Methods
        public PseudoLocator(int area, int id)
            : base(area)
        {
            _ID = id;
        }

        #region Locator
        public override LocatorRange checkRange(Locator locator)
        {
            if (locator is PseudoLocator pseudo_locator)
            {
                return _ID == pseudo_locator._ID ? LocatorRange.InRange : LocatorRange.OutRange;
            }
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
