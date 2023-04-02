using System.Collections.Generic;
using until.system;


namespace until.test3
{
    public abstract class Context
    {
        #region Definition
        protected abstract void onUpdate(in DeltaSituation elapsed_time);
        #endregion

        #region Properties
        #endregion

        #region Fields
        #endregion

        #region Methods
        public void update(in DeltaSituation ds)
        {
            onUpdate(ds);
        }

        #endregion
    }
}
