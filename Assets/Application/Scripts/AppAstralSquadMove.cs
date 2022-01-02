using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.modules.astral;
using until.utils;
using until.develop;


namespace until.test
{
    public class AppAstralSquadMove : AppAstralSquadActionBase
    {
        #region Fields
        private Vector3 _TargetPosition = Vector3.zero;
        private float _Range = 2.0f;
        private float _RandomRange = 1.0f;
        #endregion

        #region Methods
        public AppAstralSquadMove(AppAstralOrganizationSquad squad, int target_sector)
            : base(squad)
        {
            var db = Singleton.AppAstralWorldDatabase.getLevelDatabase(new AppStageIdentifier(LevelID.lv_003_001_00));
            if (target_sector < 0)
            {
                target_sector = math.getRandomIndex(db.Waypoints.Waypoints.Length);
            }
            var sector_position = db.Waypoints.getSectorPosition(target_sector);
            if (sector_position != null)
            {
                _TargetPosition = sector_position.Value;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} {_TargetPosition}";
        }

        #region AstralAction
        public override void onAstralActionStart()
        {
        }

        public override bool onAstralActionUpdate(float delta_time)
        {
            foreach (var member in RefSquad.MemberList)
            {
                var gap = member.Position - _TargetPosition;
                if (gap.magnitude > _Range)
                {
                    return true;
                }
            }

            return false;
        }

        public override void onAstralActionEnd()
        {
        }

        public override void onAstralInterceptEstablished(AstralInterfereable interferer)
        {
        }

        #endregion

        #region AppAstralSquadActionBase
        public override AstralAction getMemberAstralAction(AppSubstanceCharacter substance)
        {
            var target = _TargetPosition;
            //target.x += math.getRandomRange(-_RandomRange, _RandomRange);
            //target.z += math.getRandomRange(-_RandomRange, _RandomRange);
            return new AppAstralActionNpcSquadMove(substance, target);
        }
        #endregion
        #endregion
    }
}
