using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;
using until.modules.gamefield;
using until.modules.gamemaster;
using until.develop;


namespace until.test2
{
    public class ModeIngameSetup : Mode
    {
        #region definitions
        private enum Phase
        {
            Start,
            IngameField_Setup,
            StageSetupRequest,
            StageSetupWait,
            TransitNextMode,
            End,
        }
        #endregion

        #region fields
        private Phase _CurrentPhase = Phase.Start;
        #endregion

        #region methods.
        #region mode
        public Mode.Control init()
        {
            _CurrentPhase = Phase.Start;
            return Mode.Control.Done;
        }

        public Mode.Control update()
        {
            switch (_CurrentPhase)
            {
                case Phase.Start:
                    {
                        transit(Phase.IngameField_Setup);
                    }
                    return Mode.Control.Keep;
                case Phase.IngameField_Setup:
                    {
                        foreach (var stage in BuildinSceneIndex.Category_AppStage)
                        {
                            var path = BuildinSceneIndex.Paths[stage];
                            var symbol = Path.GetFileNameWithoutExtension(path);
                            if (Enum.TryParse<IdentifierStage>(symbol, out var id))
                            {
                                var controller = new StageSceneController(new TestStageIdentifier(id), stage);
                                Singleton.StageSceneManager.regist(controller);
                            }
                        }
                        transit(Phase.StageSetupRequest);
                    }
                    return Mode.Control.Keep;
                case Phase.StageSetupRequest:
                    {
                        transit(Phase.StageSetupWait);
                        var builder = new StageSetupOrderBuilder();
                        // プレイヤーのセットアップ
                        builder.add(new TestStageIdentifier(IdentifierStage.lv_003_001_00), StageSceneStatus.Active);
                        builder.add(GameEntityIdentifiable.until_test2_IdentifierCharacter_Ch03000, new GameEntitySerializableIdentifier("0"), Vector3.zero);
                        var order = builder.build();
                        Singleton.StageSetupper.request(order, () => transit(Phase.TransitNextMode));
                    }
                    return Mode.Control.Keep;
                case Phase.StageSetupWait:
                    {

                    }
                    return Mode.Control.Keep;
                case Phase.TransitNextMode:
                    {
                        Singleton.ModeManager.enqueueNextMode<ModeIngame>();
                        transit(Phase.End);
                    }
                    return Mode.Control.Keep;
                case Phase.End:
                    return Mode.Control.Done;
            }


            return Mode.Control.Done;
        }

        public Mode.Control exit()
        {
            return Mode.Control.Done;
        }
        #endregion

        #region ModeIngameSetup
        private void transit(Phase next)
        {
            Log.info(this, $"transit {_CurrentPhase} > {next}");
            _CurrentPhase = next;
        }
        #endregion
        #endregion
    }

}

