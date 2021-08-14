#if TEST
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.develop;
using until.system;
using until.modules.astral;
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


        private int createID(int category, int floor, int area, int id)
        {
            return category << 24 | floor << 16 | area << 8 | id;
        }

        private void updateConstructAstral()
        {
            var world = new World();

            // �����\��
            var space_homebase = world.createSpace(createID(1, 0, 0, 0), "���_");
            var space_homebase_reception = world.createSpace(createID(1, 1, 1, 0), "���_.��t");
            var space_homebase_office = world.createSpace(createID(1, 1, 2, 0), "���_.������");
            var space_dungeon = world.createSpace(createID(2, 0, 0, 0), "���{");
            var space_dungeon_1f_a = world.createSpace(createID(2, 1, 1, 0), "���{.1F.A");
            var space_dungeon_1f_b = world.createSpace(createID(2, 1, 2, 0), "���{.1F.B");
            space_homebase.regist(space_homebase_reception);
            space_homebase.regist(space_homebase_office);
            space_dungeon.regist(space_dungeon_1f_a);
            space_dungeon.regist(space_dungeon_1f_b);

            // �X�|�b�g�\��
            var spot_homebase_counter = world.createSpot(createID(1, 1, 1, 1), "���_.��t.�J�E���^�[");
            space_homebase_reception.regist(spot_homebase_counter);
            var spot_dungeon_mine = world.createSpot(createID(2, 1, 1, 1), "���{.1F.A.�̌@");
            space_dungeon_1f_a.regist(spot_dungeon_mine);

            // ���炩�̃A�o�^�[
            var avatar = world.createBody(createID(0, 0, 0, 1), "��l���L����");

            // ���낤�낷��X�R�A
            var score = new AstralScore();
            score.appendNote(new modules.astral.note.BeginBehavior(TestAstralRole.Leader, TestAstralBehaviorIdentifier.StatusWait), true);

            // �Z�b�V����
            var session = new AstralSession();
            session.assign(TestAstralRole.Leader, avatar);
            session.bind(score);
            world.regist(session);

            singleton.AstralAdministrator.Instance.regist(world);

            transit(Phase.Transit);
        }
        #endregion
        #endregion
    }
}
#endif
