using System.Collections.Generic;


namespace until.test3
{
    public class PseudoLocationAreaControl : LocationAreaControl
    {
        #region Definition
        #endregion

        #region Properties
        #endregion

        #region Fields
        private List<PseudoFixedLocator> _FixedLocatorCollection = null;
        private List<PseudoMobileLocator> _MobileLocatorCollection = null;
        #endregion

        #region Methods
        public PseudoLocationAreaControl(int area)
            : base(area)
        {
            _FixedLocatorCollection = new List<PseudoFixedLocator>();
            _MobileLocatorCollection = new List<PseudoMobileLocator>();
        }

        #region Management
        public void regist(PseudoFixedLocator locator)
        {
            _FixedLocatorCollection.Add(locator);
        }

        public void regist(PseudoMobileLocator locator)
        {
            _MobileLocatorCollection.Add(locator);
        }

        public void unregist(PseudoFixedLocator locator)
        {
            _FixedLocatorCollection.Remove(locator);
        }

        public void unregist(PseudoMobileLocator locator)
        {
            _MobileLocatorCollection.Remove(locator);
        }
        #endregion

        #region LocationAreaControl
        public override Locator[] extractLocation(LocatorRange range)
        {
            return EMPTY_LOCAION_LIST;
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
