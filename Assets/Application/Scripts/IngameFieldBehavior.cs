using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.system;


namespace until.test
{
    [DefaultExecutionOrder(until.system.defines.ExecutionOrder.ApplicationStart)]
    public class IngameFieldBehavior : Behavior
    {
        private void Start()
        {
            Singleton.IngameField.onStart();
        }

        private void Update()
        {
            Singleton.IngameField.onUpdate();
        }

        private void OnDestroy()
        {
            Singleton.IngameField.onDestroy();
        }
    }
}
