#if TEST
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;


namespace until.singleton
{
    public class DevelopManager : Singleton<DevelopManager>
    {
        #region Singleton
        public override void onSingletonAwake()
        {
        }

        public override void onSingletonStart()
        {
        }

        public override void onSingletonDestroy()
        {
        }
        #endregion
    }
}
#endif
