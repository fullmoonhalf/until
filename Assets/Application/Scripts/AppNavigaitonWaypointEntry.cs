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
    [DisallowMultipleComponent]
    [DefaultExecutionOrder(until.system.settings.UntilBehaviorOrder.System_SettingBehavior)]
    public class AppNavigaitonWaypointEntry : SettingBehavior
    {
        public Vector3 Position { get; private set; }

        void Awake()
        {
            Position = gameObject.transform.position;
        }
    }
}
