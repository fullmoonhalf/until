using System.Collections.Generic;
using until.system;


namespace until.test3
{
    public class LocationAggregator
    {
        #region Definition
        public readonly int NULL_LOCATOIN_AREA_ID = -1;
        #endregion

        #region Properties
        #endregion

        #region Fields
        private Dictionary<int, LocationAreaControl> _AreaControlCollection = null;
        private NullLocationAreaControl _NullLocationAreaControl = null;
        #endregion

        #region Methods
        public LocationAggregator()
        {
            _AreaControlCollection = new Dictionary<int, LocationAreaControl>();
            _NullLocationAreaControl = new NullLocationAreaControl(NULL_LOCATOIN_AREA_ID);
        }

        #region Element
        public void regist(LocationAreaControl control)
        {
            _AreaControlCollection[control.Area] = control;
        }

        public void unregist(LocationAreaControl control)
        {
            _AreaControlCollection.Remove(control.Area);
        }

        public LocationAreaControl getLocationAreaControl(int area)
        {
            if (_AreaControlCollection.TryGetValue(area, out var lac))
            {
                return lac;
            }
            else
            {
                return _NullLocationAreaControl;
            }
        }
        #endregion
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
