using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using until.modules.astral;
using until.modules.gamefield;
using until.modules.gamemaster;


namespace until.test
{
    public class AppAstralCompanyCombat : AppAstralCompanyActionBase
    {
        #region Fields
        private AppAstralLevelDatabase _LevelDatabase = null;
        private Substance _RefPlayer = null;
        private int _PlayerSector = -1;
        #endregion

        #region Methods
        public AppAstralCompanyCombat(AppAstralOrganizationCompany company)
            : base(company)
        {
        }

        #region AppAstralCompanyActionBase
        public override void onAstralActionStart()
        {
            _LevelDatabase = Singleton.AppAstralWorldDatabase.getLevelDatabase(new AppStageIdentifier(LevelID.lv_003_001_00));
            _RefPlayer = Singleton.SubstanceManager.get(new GameEntitySerializableIdentifier("0"));
        }

        public override bool onAstralActionUpdate(float delta_time)
        {
            if (updatePlayerSectorInfo())
            {
                var interferer = new AppAstralInterfererOnCombatSectorUpdate();
                foreach (var squad in RefCompany.SquadList)
                {
                    Singleton.AstralManager.interfere(interferer, squad.Element);
                }
            }
            return true;
        }

        public override void onAstralActionEnd()
        {
        }

        public override void onAstralInterceptEstablished(AstralInterfereable interferer)
        {
        }

        public override bool onAstralInterceptTry(AstralInterfereable interferer)
        {
            return false;
        }

        public override AstralAction getSquadAstralAction(AppAstralOrganizationSquad squad)
        {
            return null;
        }
        #endregion

        #region MyRegion
        private bool updatePlayerSectorInfo()
        {
            if (_LevelDatabase == null)
            {
                return false;
            }
            if (_RefPlayer == null)
            {
                return false;
            }

            var previous = _PlayerSector;
            var min_distance = float.MaxValue;
            for (int index = 0; index < _LevelDatabase.Waypoints.Waypoints.Length; ++index)
            {
                var waypoint = _LevelDatabase.Waypoints.Waypoints[index];
                var gap = waypoint.Position - _RefPlayer.Position;
                var distance = gap.magnitude;
                if (min_distance > distance)
                {
                    min_distance = distance;
                    _PlayerSector = index;
                }
            }
            return previous != _PlayerSector;
        }
        #endregion
        #endregion
    }
}
