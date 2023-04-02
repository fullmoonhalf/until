using until.system;
using UnityEngine;


namespace until.test3
{
    public class ModeIngameRunning : Mode
    {
        #region definitions
        #endregion

        #region fields
        #endregion

        #region methods.
        #region mode
        public Mode.Control init()
        {
            return Mode.Control.Done;
        }

        public Mode.Control update()
        {
            var ds = new DeltaSituation(Time.deltaTime);
            Singleton.ContextManager.update(ds);
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

