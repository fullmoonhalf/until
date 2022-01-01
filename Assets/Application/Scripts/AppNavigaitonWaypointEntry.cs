using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;
using until.system;
using until.develop;


namespace until.test
{
    [DisallowMultipleComponent]
    [DefaultExecutionOrder(until.system.settings.UntilBehaviorOrder.System_SettingBehavior)]
    public class AppNavigaitonWaypointEntry : SettingBehavior
    {
        #region inspector
        public AppNavigaitonWaypointEntry[] NextPoint = null;
        #endregion

        #region properties
        public Vector3 Position { get; private set; }
        #endregion

        #region methods
        void Awake()
        {
            Position = gameObject.transform.position;
        }

        #region Develop
#if TEST
        void OnDrawGizmos()
        {
            var source = gameObject.transform.position;
            Gizmos.DrawWireCube(source, Vector3.one);
            if (NextPoint != null)
            {
                foreach (var next in NextPoint)
                {
                    if (next != null)
                    {
                        var target = next.gameObject.transform.position;
                        var half = (source + target) * 0.5f;
                        Gizmos.DrawLine(source, half);
                    }
                }
            }
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(gameObject.transform.position, 2.0f);
        }
#endif
        #endregion
        #endregion
    }
}
