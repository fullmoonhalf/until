using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.modules.astral;
using until.modules.gamefield;
using until.modules.gamemaster;
using until.develop;


namespace until.test
{
    public class AppAstralCompanyCombat : AppAstralCompanyActionBase
    {
        #region Definition
        private class BattleOrder
        {
            public AppAstralOrganizationSquad Squad;
            public Vector3 PositionZero;
            public int TargetSector = -1;

            public BattleOrder(AppAstralOrganizationSquad squad)
            {
                Squad = squad;
            }
        }
        private class BattleOrderSolver
        {
            public BattleOrder[] BattleOrderList = null;

            public BattleOrderSolver(AppAstralOrganizationSquad[] squad_list, Vector3 position)
            {
                var list = new List<BattleOrder>(squad_list.Length);
                for (int index = 0; index < squad_list.Length; ++index)
                {
                    var order = new BattleOrder(squad_list[index]);
                    order.PositionZero = order.Squad.getPositionZero();
                    list.Add(order);
                }
                BattleOrderList = list.ToArray();
            }
        }
        #endregion

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
                var waypoints = _LevelDatabase.Waypoints.getWaypointsNearestList(_PlayerSector);
                var solver = new BattleOrderSolver(RefCompany.SquadList, _RefPlayer.Position);

                for (int waypoints_order = 0; waypoints_order < waypoints.Length; ++waypoints_order)
                {
                    var waypoint_sector = waypoints[waypoints_order];
                    var waypoint_position = _LevelDatabase.Waypoints.Waypoints[waypoint_sector].Position;
                    var min_distance = float.MaxValue;
                    BattleOrder selected_squad = null;
                    for (int squad_index = 0; squad_index < solver.BattleOrderList.Length; ++squad_index)
                    {
                        var order = solver.BattleOrderList[squad_index];
                        if (order.TargetSector < 0)
                        {
                            var distance = Vector3.Distance(order.PositionZero, waypoint_position);
                            if (min_distance > distance)
                            {
                                min_distance = distance;
                                selected_squad = order;
                            }
                        }
                    }
                    if (selected_squad != null)
                    {
                        selected_squad.TargetSector = waypoint_sector;
                    }
                }

                for (int index = 0; index < solver.BattleOrderList.Length; ++index)
                {
                    var order = solver.BattleOrderList[index];
                    var interferer = new AppAstralInterfererOnCombatSectorUpdate(order.TargetSector);
                    Singleton.AstralManager.interfere(interferer, order.Squad.Element);
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

        public override AstralInterceptResult onAstralInterceptTry(AstralInterfereable interferer)
        {
            return AstralInterceptResult.Cancel_Through;
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
            _PlayerSector = _LevelDatabase.Waypoints.getNearestWaypoint(_RefPlayer.Position);
            return previous != _PlayerSector;
        }
        #endregion
        #endregion
    }
}
