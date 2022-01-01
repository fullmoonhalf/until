using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.system;
using until.develop;


namespace until.test
{
    [DefaultExecutionOrder(until.system.settings.UntilBehaviorOrder.System_SettingBehavior)]
    public class AppNavigationWaypointsCollection : SettingBehavior
    {
        #region Inspector
        [SerializeField]
        private LevelID _Level = LevelID.Invalid;
        #endregion

        #region Properties
        public AppNavigaitonWaypointEntry[] Waypoints => _Waypoints;
        #endregion

        #region Fields
        private AppAstralLevelDatabase _RefLevelDatabase = null;
        private AppNavigaitonWaypointEntry[] _Waypoints = null;
        #endregion

        #region Methods
        private void Awake()
        {
        }

        private void Start()
        {
            _Waypoints = gameObject.GetComponentsInChildren<AppNavigaitonWaypointEntry>();
            _RefLevelDatabase = Singleton.AppAstralWorldDatabase.getLevelDatabase(new AppStageIdentifier(_Level));
            _RefLevelDatabase.Waypoints = this;
        }

        private void OnDestroy()
        {
            _RefLevelDatabase.Waypoints = null;
        }
        #endregion

        #region Develop
#if TEST
        [ContextMenu(nameof(fixupLink))]
        private void fixupLink()
        {
            // インデックスを決める
            var waypoints = gameObject.GetComponentsInChildren<AppNavigaitonWaypointEntry>();
            var wayindecies = new Dictionary<AppNavigaitonWaypointEntry, int>();
            foreach (var waypoint in waypoints)
            {
                var index = wayindecies.Count;
                wayindecies.Add(waypoint, index);
            }

            // リンク構造を決める
            var linkdb = new bool[waypoints.Length, waypoints.Length];
            for (int index = 0; index < waypoints.Length; ++index)
            {
                var myself_waypoint = waypoints[index];
                var myself_index = wayindecies[myself_waypoint];
                for (int subidx = 0; subidx < myself_waypoint.NextPoint.Length; ++subidx)
                {
                    var next_waypoint = myself_waypoint.NextPoint[subidx];
                    var next_index = wayindecies[next_waypoint];
                    linkdb[myself_index, next_index] = true;
                    linkdb[next_index, myself_index] = true;
                }
            }

            // 足りないのを追加する。
            for (int myself = 0; myself < waypoints.Length; ++myself)
            {
                var neighbours = new List<AppNavigaitonWaypointEntry>();
                for (int target = 0; target < waypoints.Length; ++target)
                {
                    if (linkdb[myself, target])
                    {
                        var target_waypoint = waypoints[target];
                        neighbours.Add(target_waypoint);
                    }
                }

                var myself_waypoint = waypoints[myself];
                myself_waypoint.NextPoint = neighbours.ToArray();
            }
        }
#endif
        #endregion
    }
}
