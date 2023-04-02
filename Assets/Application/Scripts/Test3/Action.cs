using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace until.test3
{
    public abstract class Action
    {
        #region Definition
        public abstract Action onUpdate(in DeltaSituation ds);
        #endregion

        #region Develop
#if TEST
        public virtual string DebugStatus
        {
            get => $"{GetType().Name}";
        }
#endif
        #endregion
    }
}
