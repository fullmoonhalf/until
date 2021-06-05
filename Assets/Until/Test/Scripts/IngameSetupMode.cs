#if TEST
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.develop;
using until.system;
using until.modules.astral.standard;


namespace until.test
{
    public class IngameSetupMode : Mode
    {
        #region Definition.
        private enum Phase
        {
            Initial,
            ConstructAstral,
            Transit,
            Exit,
        }
        #endregion

        #region Fields.
        private Phase _CurrentPhase = Phase.Initial;
        #endregion

        #region Methods
        #region Mode
        public Mode.Control init()
        {
            TestLog.test(this, "init");
            return Mode.Control.Done;
        }

        public Mode.Control update()
        {
            var result = Mode.Control.Keep;

            switch (_CurrentPhase)
            {
                case Phase.Initial:
                    transit(Phase.ConstructAstral);
                    break;
                case Phase.ConstructAstral:
                    updateConstructAstral();
                    break;
                case Phase.Transit:
                    singleton.ModeManager.Instance.enqueueNextMode<IngameMode>();
                    transit(Phase.Exit);
                    result = Mode.Control.Done;
                    break;
                case Phase.Exit:
                    result = Mode.Control.Done;
                    break;
            }

            return result;
        }

        public Mode.Control exit()
        {
            TestLog.test(this, "exit");
            return Mode.Control.Done;
        }
        #endregion

        #region Phase
        private void transit(Phase next)
        {
            TestLog.test(this, $"transit {_CurrentPhase} => {next}");
            _CurrentPhase = next;
        }


        private void updateConstructAstral()
        {
            var world = new World();
            var space = world.createSpace(0);
            var spot = world.createSpace(1);
            var body = world.createBody(2);
            space.regist(spot);

            transit(Phase.Transit);
        }
        #endregion
        #endregion
    }
}
#endif
