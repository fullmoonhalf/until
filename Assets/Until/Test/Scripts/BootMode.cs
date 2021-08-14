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
                    Singleton.DevelopIndicator.create<DevelopIndicatorFrameCounter>(DevelopIndicatorAnchor.LeftTop);
                    Singleton.DevelopIndicator.create<DevelopIndicatorFrameProfile>(DevelopIndicatorAnchor.LeftTop);
                    Singleton.DevelopIndicator.regist(Singleton.InputManager, DevelopIndicatorAnchor.LeftBottom);
                    Singleton.DevelopIndicator.regist(Singleton.ModeManager, DevelopIndicatorAnchor.RightTop);
                    Singleton.DevelopIndicator.regist(Singleton.CameraManager, DevelopIndicatorAnchor.RightTop);
                    Singleton.DevelopIndicator.regist(Singleton.SceneLoader, DevelopIndicatorAnchor.RightBottom);
                    Singleton.DevelopCommandManager.addPage("test");
                    Singleton.DevelopCommandManager.addCommand("test", new DevelopCommandBool("t1", "t1", false));
                    Singleton.DevelopCommandManager.addCommand("test", new DevelopCommandBool("t2", "t2", true));
                    Singleton.DevelopCommandManager.addCommand("test", new DevelopCommandInt("t3", "t3", 0));
                    Singleton.DevelopCommandManager.addCommand("test", new DevelopCommandInt("t4", "t4", 0, -10, 10));
                    Singleton.DevelopCommandManager.addPage("test2");
                    Singleton.DevelopCommandManager.addCommand("test2", new DevelopCommandFloat("t4", "t4", 0.0f));
                    Singleton.DevelopCommandManager.addCommand("test2", new DevelopCommandFloat("t5", "t5", 0.0f, 0.1f));
                    Singleton.DevelopCommandManager.addCommand("test2", new DevelopCommandFloat("t6", "t6", 0.0f, 0.1f, -0.5f, 0.5f));
                    Singleton.DevelopCommandManager.addCommand("test2", new DevelopCommandBool("t2", "t2", true));
                    Singleton.DevelopCommandManager.addCommand("test2", new DevelopCommandBool("t1", "t1", false));
                    Singleton.DevelopCommandManager.addCommand("test2", new DevelopCommandInt("t3", "t3", 0));
                    Singleton.DevelopCommandManager.addCommand("test2", new DevelopCommandInt("t7", "t7", 0, -10));
                    Singleton.DevelopCommandManager.addCommand("test2", new DevelopCommandInt("t8", "t8", 0, -10, 10));
                    transit(Phase.StartCameraLoad);
                    break;
                case Phase.StartCameraLoad:
                    Singleton.SceneLoader.requestToLoad(SceneIndex_Camera, () => _CurrentPhase = Phase.NextMode);
                    break;
                case Phase.WaitCameraLoad:
                    break;
                case Phase.NextMode:
                    Singleton.CameraManager.transitCamera<CameraActionFree>();
                    Singleton.ModeManager.enqueueNextMode<IngameSetupMode>();
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
