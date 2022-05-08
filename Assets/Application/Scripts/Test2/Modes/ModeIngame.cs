using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;


namespace until.test2
{
    public class ModeIngame : Mode
    {
        #region methods.
        #region mode
        public Mode.Control init()
        {
            return Mode.Control.Done;
        }

        public Mode.Control update()
        {
            return Mode.Control.Keep;
        }

        public Mode.Control exit()
        {
            return Mode.Control.Done;
        }
        #endregion
        #endregion
    }
}

