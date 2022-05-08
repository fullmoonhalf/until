#if TEST
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.develop;
using until.system;
using until.modules.gamemaster;
using until.modules.gamefield;
using until.modules.bullet;
using until.utils;


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
            CameraSetup,
            SquadSetup,
            Transit,
            Exit,
        }

        private const int EnemyCount = 30;
        private const int SquadCapacity = 3;
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
                        var bullet_01 = new BulletPoolSpecifier() { PrefabName = "Bullet0001", Count = 50 };
                        var bullet_02 = new BulletPoolSpecifier() { PrefabName = "Bullet0002", Count = 500 };
                        var order = new BulletPoolOrder() { SpecifierList = new BulletPoolSpecifier[] { bullet_01, bullet_02, } };
                        Singleton.BulletManager.buildBulletPool(order);
                        transit(Phase.StageSetup);
                    }
                    break;
                case Phase.StageSetup:
                    {
                        transit(Phase.StageWait);
                        var builder = new StageSetupOrderBuilder();
                        // プレイヤーのセットアップ
                        builder.add(new AppStageIdentifier(LevelID.lv_003_001_00), StageSceneStatus.Active);
                        builder.add(GameEntityIdentifiable.until_test_CharacterID_Ch01000, new GameEntitySerializableIdentifier("0"), Vector3.zero);
                        // 敵キャラのセットアップ
                        for (var index = 0; index < EnemyCount; ++index)
                        {
                            var x = math.getRandomRange(-3.0f, 3.0f);
                            var z = math.getRandomRange(-3.0f, 3.0f);
                            builder.add(GameEntityIdentifiable.until_test_CharacterID_Ch12000, new GameEntitySerializableIdentifier($"{1 + index}"), new Vector3(x, 0, z));
                        }
                        var order = builder.build();
                        Singleton.StageSetupper.request(order, () => transit(Phase.CameraSetup));
                    }
                    break;
                case Phase.StageWait:
                    break;
                case Phase.CameraSetup:
                    Singleton.CameraManager.transitCamera<AppCameraActoinPlayerFollow>();
                    transit(Phase.SquadSetup);
                    break;
                case Phase.SquadSetup:
                    {
                        var local_db = Singleton.AppAstralWorldDatabase.getLevelDatabase(new AppStageIdentifier(LevelID.lv_003_001_00));
                        var waypoint_index = math.getRandomIndex(local_db.Waypoints.Waypoints.Length);
                        var company = new AppAstralOrganizationCompany();
                        //Singleton.AstralOrganizationManager.regist(company);
                        AppAstralOrganizationSquad squad = null;
                        for (var index = 0; index < EnemyCount; ++index)
                        {
                            if (squad != null)
                            {
                                if (squad.Population >= squad.Capacity)
                                {
                                    squad = null;
                                }
                            }
                            if (squad == null)
                            {
                                squad = new AppAstralOrganizationSquad(SquadCapacity);
                                company.regist(squad);
                                //Singleton.AstralOrganizationManager.regist(squad);
                                waypoint_index = math.getRandomIndex(local_db.Waypoints.Waypoints.Length);
                            }

                            var identifier = new GameEntitySerializableIdentifier($"{1 + index}");
                            var substance = Singleton.SubstanceManager.get(identifier) as AppSubstanceEnemy;
                            if (substance != null)
                            {
                                var pos = local_db.Waypoints.Waypoints[waypoint_index].Position;
                                pos.x += math.getRandomRange(-3.0f, 3.0f);
                                pos.z += math.getRandomRange(-3.0f, 3.0f);
                                substance.warp(pos);

                                substance.bind(squad);
                                squad.regist(substance);
                            }
                        }
                        transit(Phase.Transit);
                    }
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
