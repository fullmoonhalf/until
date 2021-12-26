#if TEST
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.develop;
using until.system;
using until.modules.gamemaster;
using until.modules.gamefield;
using until.modules.bullet;


namespace until.test
{
    public class AppmodeIngameSetup : Mode
    {
        #region Definition.
        private enum Phase
        {
            Initial,
            SetupBullet,
            StageSetup,
            StageWait,
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
                    transit(Phase.SetupBullet);
                    break;
                case Phase.SetupBullet:
                    {
                        var bullet_01 = new BulletPoolSpecifier() { PrefabName = "Bullet0001", Count = 500 };
                        var order = new BulletPoolOrder() { SpecifierList = new BulletPoolSpecifier[1] { bullet_01 } };
                        Singleton.BulletManager.buildBulletPool(order);
                        transit(Phase.StageSetup);
                    }
                    break;
                case Phase.StageSetup:
                    {
                        transit(Phase.StageWait);
                        var builder = new StageSetupOrderBuilder();
                        builder.add(new AppStageIdentifier(StageID.lv_003_001_00), StageSceneStatus.Active);
                        builder.add(GameEntityIdentifiable.until_test_CharacterID_Ch01000, Vector3.zero);
                        builder.add(GameEntityIdentifiable.until_test_CharacterID_Ch01001, Vector3.one);
                        var order = builder.build();
                        Singleton.StageSetupper.request(order, () => transit(Phase.Transit));
                    }
                    break;
                case Phase.StageWait:
                    break;
                case Phase.Transit:
                    Singleton.ModeManager.enqueueNextMode<AppmodeIngame>();
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
        #endregion
        #endregion
    }
}
#endif
