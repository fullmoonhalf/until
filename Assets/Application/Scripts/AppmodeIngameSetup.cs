#if TEST
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.develop;
using until.system;
using until.modules.astral;
using until.modules.astral.standard;
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
            ConstructAstral,
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
                        transit(Phase.ConstructAstral);
                    }
                    break;
                case Phase.ConstructAstral:
                    updateConstructAstral();
                    transit(Phase.StageSetup);
                    break;
                case Phase.StageSetup:
                    {
                        transit(Phase.StageWait);
                        var builder = new StageSetupOrderBuilder();
                        builder.add(new AppStageIdentifier(StageID.lv_003_001_00), StageSceneStatus.Active);
                        builder.add(GameEntityIdentifiable.until_test_CharacterID_Ch01000);
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


        private int createID(int category, int floor, int area, int id)
        {
            return category << 24 | floor << 16 | area << 8 | id;
        }

        private void updateConstructAstral()
        {
            var world = new TestAstralWorld();

            // �����\��
            var space_homebase = world.createSpace(createID(1, 0, 0, 0), "���_");
            var space_homebase_reception = world.createSpace(createID(1, 1, 1, 0), "���_.��t");
            var space_homebase_office = world.createSpace(createID(1, 1, 2, 0), "���_.������");
            var space_dungeon = world.createSpace(createID(2, 0, 0, 0), "���{");
            var space_dungeon_1f_a = world.createSpace(createID(2, 1, 1, 0), "���{.1F.A");
            var space_dungeon_1f_b = world.createSpace(createID(2, 1, 2, 0), "���{.1F.B");
            var space_battle_field = world.createSpace(createID(3, 0, 0, 0), "�퓬�t�B�[���h");
            var space_battle_field_1 = world.createSpace(createID(3, 1, 0, 0), "�퓬�t�B�[���h.1");
            space_homebase.regist(space_homebase_reception);
            space_homebase.regist(space_homebase_office);
            space_dungeon.regist(space_dungeon_1f_a);
            space_dungeon.regist(space_dungeon_1f_b);
            space_battle_field.regist(space_battle_field_1);

            // �X�|�b�g�\��
            var spot_homebase_counter = world.createBody(createID(1, 1, 1, 1), "���_.��t.�J�E���^�[");
            space_homebase_reception.regist(spot_homebase_counter);
            var spot_dungeon_mine = world.createBody(createID(2, 1, 1, 1), "���{.1F.A.�̌@");
            space_dungeon_1f_a.regist(spot_dungeon_mine);

            // ���炩�̃A�o�^�[
            var avatar = createAvatar(createID(0, 0, 0, 0), world, space_battle_field_1, "��l���L����");
            createAvatar(createID(0, 0, 0, 1), world, space_battle_field_1, "NPC�L����");

            // ���낤�낷��X�R�A
            var score = new AstralScore();
            score.appendNote(new modules.astral.note.BeginBehavior(TestAstralRole.Leader, TestAstralBehaviorOperation.StatusWait), true);

            // �Z�b�V����
            var session = new AstralSession();
            session.assign(TestAstralRole.Leader, avatar);
            session.bind(score);
            world.regist(session);

            Singleton.AstralAdministrator.regist(world);
        }

        private AstralBody createAvatar(int id, AstralWorld world, AstralSpace space, string name)
        {
            var avatar_gmid = new GameEntityIdentifier(id);
            var avatar = world.createBody(id, name);
            space.regist(avatar);
            Singleton.GameMaster.set(avatar_gmid, TestGMParameterIdentifier.HP, TestGMAffairIdentifier.Initial, 100);
            return avatar;
        }


        #endregion
        #endregion
    }
}
#endif
