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
    }
}
