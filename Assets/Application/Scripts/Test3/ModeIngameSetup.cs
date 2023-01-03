using until.system;


namespace until.test3
{
    public class ModeIngameSetup : Mode
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
            Singleton.ModeManager.enqueueNextMode<ModeIngameRunning>();
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

