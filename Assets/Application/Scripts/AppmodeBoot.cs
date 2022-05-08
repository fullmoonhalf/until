#if TEST
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;
using until.develop;
using until.modules.camera;
using until.modules.gamefield;
using until.test2;

namespace until.test
{
    public class AppmodeBoot : until.system.BootMode
    {
        private enum Phase
        {
            Start,
            StartDevelop,
            Camera_Start,
            Camera_Wait,
            PermanentCollection_Start,
            PermanentCollection_Wait,
            System_Start,
            System_Wait,
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
                    transit(Phase.StartDevelop);
                    break;
                case Phase.StartDevelop:
                    Singleton.DevelopIndicator.create<DevelopIndicatorFrameCounter>(DevelopIndicatorAnchor.LeftTop);
                    Singleton.DevelopIndicator.create<DevelopIndicatorFrameProfile>(DevelopIndicatorAnchor.LeftTop);
                    Singleton.DevelopIndicator.regist(Singleton.InputManager, DevelopIndicatorAnchor.LeftBottom);
                    Singleton.DevelopIndicator.regist(Singleton.ModeManager, DevelopIndicatorAnchor.RightTop);
                    Singleton.DevelopIndicator.regist(Singleton.CameraManager, DevelopIndicatorAnchor.RightTop);
                    Singleton.DevelopIndicator.regist(Singleton.BulletManager, DevelopIndicatorAnchor.RightTop);
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
                    transit(Phase.Camera_Start);
                    break;
                case Phase.Camera_Start:
                    Singleton.SceneLoader.requestToLoad(BuildinSceneIndex.CameraModule_CameraModule, () => _CurrentPhase = Phase.PermanentCollection_Start);
                    transit(Phase.Camera_Wait);
                    break;
                case Phase.Camera_Wait:
                    break;
                case Phase.PermanentCollection_Start:
                    transit(Phase.PermanentCollection_Wait);
                    Singleton.SceneLoader.requestToLoad(1, () => transit(Phase.System_Start));
                    break;
                case Phase.PermanentCollection_Wait:
                    break;
                case Phase.System_Start:
                    Singleton.PrefabInstantiateMediator.requestFromCollection("AppSystem", (result, go) => transit(Phase.NextMode));
                    break;
                case Phase.System_Wait:
                    break;
                case Phase.NextMode:
                    Singleton.CameraManager.transitCamera<CameraActionFree>();
                    Singleton.ModeManager.enqueueNextMode<ModeIngameSetup>();
                    //Singleton.ModeManager.enqueueNextMode<test.AppmodeIngameSetup>();
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
