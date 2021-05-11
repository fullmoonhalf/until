using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;
using until.develop;
using until.modules.camera;

namespace until.test
{
    public class BootMode : until.system.BootMode
    {
        private enum Phase
        {
            Start,
            StartCameraLoad,
            WaitCameraLoad,
            NextMode,
            Finish,
        }
        private Phase _CurrentPhase = Phase.Start;

        private const int SceneIndex_Camera = 0;



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
                    transit(Phase.StartCameraLoad);
                    break;
                case Phase.StartCameraLoad:
                    singleton.SceneLoader.Instance.requestToLoad(SceneIndex_Camera, () => _CurrentPhase = Phase.NextMode);
                    break;
                case Phase.WaitCameraLoad:
                    break;
                case Phase.NextMode:
                    singleton.CameraManager.Instance.transitCamera<CameraActionFree>();
                    singleton.ModeManager.Instance.enqueueNextMode<IngameMode>();
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
