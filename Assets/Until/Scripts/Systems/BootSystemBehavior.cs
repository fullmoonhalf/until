using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace until.system
{
    [DefaultExecutionOrder(defines.ExecutionOrder.System_Head_00)]
    public class BootSystemBehavior : Behavior
    {
        // Update is called once per frame
        void Update()
        {
            Singleton.BootSystem.onUpdate();
        }
    }
}

