using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;
using until.develop;


namespace until.test
{
    public class BootMode : until.system.BootMode
    {
        private enum Phase
        {
            Start,
            StartSceneLoad,
            WaitSceneLoad,
            NextMode,
            Finish,
        }
        private Phase _CurrentPhase = Phase.Start;

        public Mode.Control init()
        {
            TestLog.test(this, "init");
            _CurrentPhase = Phase.Start;
            return Mode.Control.Done;
        }

        public Mode.Control update()
        {
            var result = Mode.Control.Keep;
            switch (_CurrentPhase)
            {
                case Phase.Start:
                    TestLog.test(this, "update");
                    transit(Phase.StartSceneLoad);
                    break;
                case Phase.StartSceneLoad:
                    system.singleton.SceneLoader.Instance.requestToLoad(0, () => _CurrentPhase = Phase.NextMode);
                    break;
                case Phase.WaitSceneLoad:
                    break;
                case Phase.NextMode:
                    system.singleton.ModeManager.Instance.enqueueNextMode<IngameMode>();
                    transit(Phase.Finish);
                    break;
                default:
                    result = Mode.Control.Done;
                    break;
            }
            return result;
        }

        private void transit(Phase next)
        {
            TestLog.test(this, $"transit {_CurrentPhase} => {next}");
            _CurrentPhase = next;
        }

        public Mode.Control exit()
        {
            TestLog.test(this, "exit");
            return Mode.Control.Done;
        }
    }
}
