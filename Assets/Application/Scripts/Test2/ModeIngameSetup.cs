using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;


namespace until.test2
{
    public class ModeIngameSetup : Mode
    {
        #region methods.
        #region mode
        public Mode.Control init()
        {
            return Mode.Control.Done;
        }

        public Mode.Control update()
        {
            Singleton.ModeManager.enqueueNextMode<ModeIngame>();
            return Mode.Control.Done;
        }

        public Mode.Control exit()
        {
            return Mode.Control.Done;
        }
        #endregion
        #endregion
    }

}

