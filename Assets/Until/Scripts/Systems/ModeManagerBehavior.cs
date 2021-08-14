using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace until.system
{
    [DefaultExecutionOrder(defines.ExecutionOrder.System_Head_50)]
    public class ModeManagerBehavior : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            Singleton.ModeManager.onUpdate();
        }
    }
}

