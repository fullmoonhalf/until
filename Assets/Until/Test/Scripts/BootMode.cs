using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;
using until.develop;


namespace until.test
{
    public class BootMode : until.system.BootMode
    {
        public Mode.Control init()
        {
            TestLog.test(this, "init");
            return Mode.Control.Done;
        }

        public Mode.Control update()
        {
            TestLog.test(this, "update");
            system.singleton.ModeManager.Instance.enqueueNextMode<IngameMode>();
            return Mode.Control.Done;
        }

        public Mode.Control exit()
        {
            TestLog.test(this, "exit");
            return Mode.Control.Done;
        }
    }
}
