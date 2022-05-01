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
        private int[] _SectorRoute = null;
        private int _SectorIndex = 0;
        private AppAstralLevelDatabase _LocalDB = null;
        private Vector3 _StartPosition;
        #endregion

        #region Methods
        public AppAstralSquadMove(AppAstralOrganizationSquad squad, int[] sector_route, int start_index)
            : base(squad)
        {
            _LocalDB = Singleton.AppAstralWorldDatabase.getLevelDatabase(new AppStageIdentifier(LevelID.lv_003_001_00));
            _StartPosition = RefSquad.getPositionZero();
            if (sector_route != null)
            {
                _SectorRoute = sector_route;
                _SectorIndex = start_index;
                var sector_position = _LocalDB.Waypoints.getSectorPosition(_SectorRoute[_SectorIndex]);
                _TargetPosition = sector_position.Value;
            }
            else
            {
                var target_sector = math.getRandomIndex(_LocalDB.Waypoints.Waypoints.Length);
                var sector_position = _LocalDB.Waypoints.getSectorPosition(target_sector);
                _TargetPosition = sector_position.Value;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} {_TargetPosition}";
        }

        #region AstralAction
        public override void onAstralActionStart(AstralSpritable sprite)
        {
        }

        public override bool onAstralActionUpdate(AstralSpritable sprite, float delta_time)
        {
            if (checkArrival())
            {
                if (_SectorRoute == null)
                {
                    return false;
                }
                _SectorIndex++;
                if (_SectorIndex >= _SectorRoute.Length)
                {
                    return false;
                }

                var sector_position = _LocalDB.Waypoints.getSectorPosition(_SectorRoute[_SectorIndex]);
                _TargetPosition = sector_position.Value;
            }

            return true;
        }

        private bool checkArrival()
        {
            foreach (var member in RefSquad.MemberList)
            {
                var gap = member.Position - _TargetPosition;
                if (gap.magnitude > _Range)
                {
                    return false;
                }
            }

            return true;
        }

        public override void onAstralActionEnd(AstralSpritable sprite)
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
            target.x += math.getRandomRange(-_RandomRange, _RandomRange);
            target.z += math.getRandomRange(-_RandomRange, _RandomRange);
            return new AppAstralActionNpcSquadMove(substance, target);
        }
        #endregion
        #endregion
    }
}
