#if TEST
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.develop;
using until.system;
using until.modules.astral;
using until.modules.astral.standard;
using until.modules.gamemaster;


namespace until.test
{
    public class IngameSetupMode : Mode
    {
        #region Definition.
        private enum Phase
        {
            Initial,
            LoadPermanentCollection,
            WaitPermanentCollection,
            SetupSystem,
            WaitSystem,
            ConstructAstral,
            SetupLevel,
            WaitLevel,
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
                    transit(Phase.LoadPermanentCollection);
                    break;
                case Phase.LoadPermanentCollection:
                    transit(Phase.WaitPermanentCollection);
                    Singleton.SceneLoader.requestToLoad(1, () => transit(Phase.SetupSystem));
                    break;
                case Phase.WaitPermanentCollection:
                    break;
                case Phase.SetupSystem:
                    Singleton.PrefabInstantiateMediator.requestFromCollection("AppSystem", (result, go) => transit(Phase.ConstructAstral));
                    break;
                case Phase.WaitSystem:
                    break;
                case Phase.ConstructAstral:
                    updateConstructAstral();
                    transit(Phase.SetupLevel);
                    break;
                case Phase.SetupLevel:
                    Singleton.IngameField.enterLevel(createID(3, 1, 0, 0));
                    transit(Phase.WaitLevel);
                    break;
                case Phase.WaitLevel:
                    if (Singleton.IngameField.checkUnderControlLevelScene() == false)
                    {
                        transit(Phase.Transit);
                    }
                    break;
                case Phase.Transit:
                    Singleton.ModeManager.enqueueNextMode<IngameMode>();
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

            // 部屋構成
            var space_homebase = world.createSpace(createID(1, 0, 0, 0), "拠点");
            var space_homebase_reception = world.createSpace(createID(1, 1, 1, 0), "拠点.受付");
            var space_homebase_office = world.createSpace(createID(1, 1, 2, 0), "拠点.事務所");
            var space_dungeon = world.createSpace(createID(2, 0, 0, 0), "迷宮");
            var space_dungeon_1f_a = world.createSpace(createID(2, 1, 1, 0), "迷宮.1F.A");
            var space_dungeon_1f_b = world.createSpace(createID(2, 1, 2, 0), "迷宮.1F.B");
            var space_battle_field = world.createSpace(createID(3, 0, 0, 0), "戦闘フィールド");
            var space_battle_field_1 = world.createSpace(createID(3, 1, 0, 0), "戦闘フィールド.1");
            space_homebase.regist(space_homebase_reception);
            space_homebase.regist(space_homebase_office);
            space_dungeon.regist(space_dungeon_1f_a);
            space_dungeon.regist(space_dungeon_1f_b);
            space_battle_field.regist(space_battle_field_1);

            // スポット構成
            var spot_homebase_counter = world.createBody(createID(1, 1, 1, 1), "拠点.受付.カウンター");
            space_homebase_reception.regist(spot_homebase_counter);
            var spot_dungeon_mine = world.createBody(createID(2, 1, 1, 1), "迷宮.1F.A.採掘");
            space_dungeon_1f_a.regist(spot_dungeon_mine);

            // 何らかのアバター
            var avatar_gmid = new GameEntityIdentifier(createID(0, 0, 0, 1));
            var avatar = world.createBody(avatar_gmid.AstralID, "主人公キャラ");
            space_battle_field_1.regist(avatar);

            // うろうろするスコア
            var score = new AstralScore();
            score.appendNote(new modules.astral.note.BeginBehavior(TestAstralRole.Leader, TestAstralBehaviorOperation.StatusWait), true);

            // セッション
            var session = new AstralSession();
            session.assign(TestAstralRole.Leader, avatar);
            session.bind(score);
            world.regist(session);

            Singleton.AstralAdministrator.regist(world);
            Singleton.GameMaster.set(avatar_gmid, TestGMParameterIdentifier.HP, TestGMAffairIdentifier.Initial, 100);
        }
        #endregion
        #endregion
    }
}
#endif
