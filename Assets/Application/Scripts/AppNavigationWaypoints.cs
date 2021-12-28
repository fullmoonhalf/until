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
    [Serializable]
    public class AppNavigaitonWaypoint
    {
        /// <summary>
        /// 位置
        /// </summary>
        public Vector3 Position => _Position;
        [SerializeField]
        private Vector3 _Position = Vector3.zero;
    }


    public class AppNavigationWaypoints : SettingBehavior
    {
        #region Inspector
        [SerializeField]
        private LevelID _Level = LevelID.Invalid;
        [SerializeField]
        private AppNavigaitonWaypoint[] _Waypoints = null;
        #endregion

        #region Properties
        public AppNavigaitonWaypoint[] Waypoints => _Waypoints;
        #endregion

        #region Fields
        private AppAstralLevelDatabase _RefLevelDatabase = null;
        #endregion

        private void Awake()
        {
            _RefLevelDatabase = Singleton.AppAstralWorldDatabase.getLevelDatabase(new AppStageIdentifier(_Level));
            _RefLevelDatabase.Waypoints = this;
        }

        private void OnDestroy()
        {
            _RefLevelDatabase.Waypoints = null;
        }
    }
}
