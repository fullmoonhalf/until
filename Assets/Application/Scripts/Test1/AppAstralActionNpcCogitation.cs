using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using until.modules.astral;
using until.utils;


namespace until.test
{
    public class AppAstralActionNpcCogitation : AppAstralActionCogitation
    {
        #region Fields
        public override bool Trapped => _NextAction != null;
        protected AppSubstanceCharacter RefSubstance { get; private set; } = null;
        private AstralAction _NextAction = null;
        #endregion

        #region Methods
        public AppAstralActionNpcCogitation(AppSubstanceCharacter substance)
        {
            RefSubstance = substance;
        }

        #region AstralAction
        public override AstralAction getNextAstralAction(AstralSpritable sprite)
        {
            var next_action = _NextAction;
            if (next_action != null)
            {
                _NextAction = null;
                return next_action;
            }

            // グループ指示による行動選択
            if (BelongGroup != null)
            {
                next_action = BelongGroup.getMemberAstralAction(RefSubstance);
                if (next_action != null)
                {
                    return next_action;
                }
            }

            // 単体での行動選択
            var x = math.getRandomRange(-3.0f, 3.0f);
            var z = math.getRandomRange(-3.0f, 3.0f);
            var pos = new Vector3(x, 0.0f, z);
            var db = Singleton.AppAstralWorldDatabase.getLevelDatabase(new AppStageIdentifier(LevelID.lv_003_001_00));
            if (db != null && db.Waypoints != null && db.Waypoints.Waypoints.Length > 0)
            {
                var index = math.getRandomIndex(db.Waypoints.Waypoints.Length);
                pos += db.Waypoints.Waypoints[index].Position;
            }

            next_action = new AppAstralActionNpcMove(RefSubstance, pos);
            return next_action;
        }

        public override void onAstralActionStart(AstralSpritable sprite)
        {
        }
        public override bool onAstralActionUpdate(AstralSpritable sprite, float delta_time)
        {
            return false;
        }
        public override void onAstralActionEnd(AstralSpritable sprite)
        {
        }

        public override AstralInterceptResult onAstralInterceptTry(AstralInterfereable interferer)
        {
            switch (interferer)
            {
                case AppAstralInterfererBullet bullet:
                    {
                        _NextAction = new AppAstralActionNpcDamage(RefSubstance);
                        return AstralInterceptResult.Cancel_Through;
                    }
                case AppAstralInterfererOnCombatSectorUpdate onCombatSectorUpdate:
                    {
                        _NextAction = getNextAstralAction(null);
                        return AstralInterceptResult.Cancel_Through;
                    }
            }

            return AstralInterceptResult.Cancel_Through;
        }

        public override void onAstralInterceptEstablished(AstralInterfereable interferer)
        {
        }

        public override void onAstralWarp(AstralSpritable sprite, Vector3 position)
        {
        }
        #endregion
        #endregion
    }
}
