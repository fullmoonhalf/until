using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.system
{
    [DefaultExecutionOrder(defines.ExecutionOrder.System_Head_10)]
    public class InputManagerBehavior : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            singleton.InputManager.Instance.onUpdate();
        }
    }
}

