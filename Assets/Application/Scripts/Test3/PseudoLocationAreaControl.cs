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
        private List<PseudoLocator> _LocatorCollection = null;
        #endregion

        #region Methods
        public PseudoLocationAreaControl(int area)
            : base(area)
        {
            _LocatorCollection = new List<PseudoLocator>();
        }

        public void regist(PseudoLocator locator)
        {
            _LocatorCollection.Add(locator);
        }

        public void unregist(PseudoLocator locator)
        {
            _LocatorCollection.Remove(locator);
        }

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
