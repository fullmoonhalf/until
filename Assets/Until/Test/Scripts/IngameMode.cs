#if TEST
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.develop;
using until.system;


namespace until.test
{
    public class IngameMode : Mode
    {
        private bool _FirstUpdate = true;

        public Mode.Control init()
        {
            TestLog.test(this, "init");
            _FirstUpdate = true;
            return Mode.Control.Done;
        }

        public Mode.Control update()
        {
            if (_FirstUpdate)
            {
                TestLog.test(this, "update");
                _FirstUpdate = false;
            }

            Singleton.AstralAdministrator.updateAstral();

            return Mode.Control.Keep;
        }

        public Mode.Control exit()
        {
            TestLog.test(this, "exit");
            return Mode.Control.Done;
        }
    }
}
#endif
