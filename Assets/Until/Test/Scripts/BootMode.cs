#if TEST
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
            StartDevelop,
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
                    transit(Phase.StartDevelop);
                    break;
                case Phase.StartDevelop:
                    singleton.DevelopIndicator.Instance.create<DevelopIndicatorFrameCounter>(DevelopIndicatorAnchor.LeftTop);
                    singleton.DevelopIndicator.Instance.create<DevelopIndicatorFrameProfile>(DevelopIndicatorAnchor.LeftTop);
                    singleton.DevelopIndicator.Instance.regist(singleton.InputManager.Instance, DevelopIndicatorAnchor.LeftBottom);
                    singleton.DevelopIndicator.Instance.regist(singleton.ModeManager.Instance, DevelopIndicatorAnchor.RightTop);
                    singleton.DevelopIndicator.Instance.regist(singleton.CameraManager.Instance, DevelopIndicatorAnchor.RightTop);
                    singleton.DevelopIndicator.Instance.regist(singleton.SceneLoader.Instance, DevelopIndicatorAnchor.RightBottom);
                    singleton.DevelopCommandManager.Instance.addPage("test");
                    singleton.DevelopCommandManager.Instance.addCommand("test", new DevelopCommandBool("t1", "t1", false));
                    singleton.DevelopCommandManager.Instance.addCommand("test", new DevelopCommandBool("t2", "t2", true));
                    singleton.DevelopCommandManager.Instance.addCommand("test", new DevelopCommandInt("t3", "t3", 0));
                    singleton.DevelopCommandManager.Instance.addCommand("test", new DevelopCommandInt("t4", "t4", 0, -10, 10));
                    singleton.DevelopCommandManager.Instance.addPage("test2");
                    singleton.DevelopCommandManager.Instance.addCommand("test2", new DevelopCommandFloat("t4", "t4", 0.0f));
                    singleton.DevelopCommandManager.Instance.addCommand("test2", new DevelopCommandFloat("t5", "t5", 0.0f, 0.1f));
                    singleton.DevelopCommandManager.Instance.addCommand("test2", new DevelopCommandFloat("t6", "t6", 0.0f, 0.1f, -0.5f, 0.5f));
                    singleton.DevelopCommandManager.Instance.addCommand("test2", new DevelopCommandBool("t2", "t2", true));
                    singleton.DevelopCommandManager.Instance.addCommand("test2", new DevelopCommandBool("t1", "t1", false));
                    singleton.DevelopCommandManager.Instance.addCommand("test2", new DevelopCommandInt("t3", "t3", 0));
                    singleton.DevelopCommandManager.Instance.addCommand("test2", new DevelopCommandInt("t7", "t7", 0, -10));
                    singleton.DevelopCommandManager.Instance.addCommand("test2", new DevelopCommandInt("t8", "t8", 0, -10, 10));
                    transit(Phase.StartCameraLoad);
                    break;
                case Phase.StartCameraLoad:
                    singleton.SceneLoader.Instance.requestToLoad(SceneIndex_Camera, () => _CurrentPhase = Phase.NextMode);
                    break;
                case Phase.WaitCameraLoad:
                    break;
                case Phase.NextMode:
                    singleton.CameraManager.Instance.transitCamera<CameraActionFree>();
                    singleton.ModeManager.Instance.enqueueNextMode<IngameSetupMode>();
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
#endif
