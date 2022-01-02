using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;
using until.system;
using until.develop;
using until.utils.algorithm;


namespace until.test
{
    [DefaultExecutionOrder(until.system.settings.UntilBehaviorOrder.System_SettingBehavior)]
    public class AppNavigationWaypointsCollection : SettingBehavior
    {
        #region Defines
        public class DijkstraInfo : DijkstraCondition
        {
            public DijkstraInfo(AppNavigaitonWaypointEntry[] waypoints)
            {
                _Waypoints = waypoints;
                buildNeighborIndex();
            }

            public DijkstraInfo(DijkstraInfo template, int start, int goal)
            {
                _Waypoints = template._Waypoints;
                _NeighbourIndecies = template._NeighbourIndecies;
                Start = start;
                Goal = goal;
            }

            private AppNavigaitonWaypointEntry[] _Waypoints;
            private int[][] _NeighbourIndecies;

            public int Start { get; private set; }
            public int Goal { get; private set; }
            public int EntityCount => _Waypoints.Length;


            public float getLinkCost(int start, int end)
            {
                return 1.0f;
            }
            public int[] getNeighbours(int start)
            {
                return _NeighbourIndecies[start];
            }

            private void buildNeighborIndex()
            {
                var wayindecies = new Dictionary<AppNavigaitonWaypointEntry, int>();
                for (int index = 0; index < _Waypoints.Length; ++index)
                {
                    var waypoint = _Waypoints[index];
                    wayindecies.Add(waypoint, index);
                }

                _NeighbourIndecies = new int[_Waypoints.Length][];
                for (int myself_index = 0; myself_index < _Waypoints.Length; ++myself_index)
                {
                    var neighbour = new List<int>();
                    var myself_waypoint = _Waypoints[myself_index];
                    for (int subidx = 0; subidx < myself_waypoint.NextPoint.Length; ++subidx)
                    {
                        var next_waypoint = myself_waypoint.NextPoint[subidx];
                        var next_index = wayindecies[next_waypoint];
                        neighbour.Add(next_index);
                    }
                    _NeighbourIndecies[myself_index] = neighbour.ToArray();
                }
            }
        }
        #endregion

        #region Inspector
        [SerializeField]
        private LevelID _Level = LevelID.Invalid;
        [SerializeField]
        private AppNavigaitonWaypointEntry[] _Waypoints = null;
        #endregion

        #region Properties
        public AppNavigaitonWaypointEntry[] Waypoints => _Waypoints;
        #endregion

        #region Fields
        private AppAstralLevelDatabase _RefLevelDatabase = null;
        private DijkstraInfo _DijkstraFilterTemplate = null;
        #endregion

        #region Methods
        #region Behavior
        private void Awake()
        {
            _DijkstraFilterTemplate = new DijkstraInfo(_Waypoints);
        }

        private void Start()
        {
            _RefLevelDatabase = Singleton.AppAstralWorldDatabase.getLevelDatabase(new AppStageIdentifier(_Level));
            _RefLevelDatabase.Waypoints = this;
        }

        private void OnDestroy()
        {
            _RefLevelDatabase.Waypoints = null;
        }
        #endregion

        #region Path Finding.
        public int[] getPath(int start, int goal)
        {
            var filter = new DijkstraInfo(_DijkstraFilterTemplate, start, goal);
            return DijkstraResolver.resolvePath(filter);
        }

        public float[] getAllCost(int start)
        {
            var filter = new DijkstraInfo(_DijkstraFilterTemplate, start, 0);
            return DijkstraResolver.resolveAllCost(filter);
        }

        public int[] getWaypointsNearestList(int start)
        {
            var filter = new DijkstraInfo(_DijkstraFilterTemplate, start, 0);
            return DijkstraResolver.resolveNearestIndexList(filter);
        }

        public int getNearestWaypoint(Vector3 position)
        {
            var nearest = -1;
            var min_distance = float.MaxValue;
            for (int index = 0; index < Waypoints.Length; ++index)
            {
                var waypoint = Waypoints[index];
                var gap = waypoint.Position - position;
                var distance = gap.magnitude;
                if (min_distance > distance)
                {
                    min_distance = distance;
                    nearest = index;
                }
            }
            return nearest;
        }
        #endregion

        #region MyRegion
        public Vector3? getSectorPosition(int sector)
        {
            if (Waypoints != null && Waypoints.Length > 0)
            {
                return Waypoints[sector].Position;
            }
            return null;
        }
        #endregion

        #region Develop
#if TEST

        [SerializeField]
        private int TestStart;
        [SerializeField]
        private int TestGoal;

        [ContextMenu(nameof(test))]
        private void test()
        {
            var route = getPath(TestStart, TestGoal);
            if (route != null)
            {
                foreach (var node in route)
                {
                    Log.info(this, nameof(test), _Waypoints[node].gameObject.name);
                }
            }
            else
            {
                Log.error(this, nameof(test), "Not Found");
            }
        }

        [ContextMenu(nameof(fixupLink))]
        private void fixupLink()
        {
            // undo buffer に積んでおく + インデックスを決める
            var filter = new DijkstraInfo(new DijkstraInfo(_Waypoints), TestStart, TestGoal);
            var waypoints = gameObject.GetComponentsInChildren<AppNavigaitonWaypointEntry>();
            var wayindecies = new Dictionary<AppNavigaitonWaypointEntry, int>();
            var edit_targets = new UnityEngine.Object[waypoints.Length + 1];
            for (int index = 0; index < waypoints.Length; ++index)
            {
                var waypoint = waypoints[index];
                edit_targets[index] = waypoint;
                wayindecies.Add(waypoint, index);
            }
            edit_targets[waypoints.Length] = this;
            Undo.RecordObjects(edit_targets, nameof(fixupLink));

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

            // 更新
            _Waypoints = waypoints;
            foreach (var edit_target in edit_targets)
            {
                EditorUtility.SetDirty(edit_target);
            }
        }
#endif
        #endregion
        #endregion
    }
}
