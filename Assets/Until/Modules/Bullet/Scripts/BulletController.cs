using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;


namespace until.modules.bullet
{
    [DefaultExecutionOrder(system.defines.ExecutionOrder.Develop_Tail_10)]
    public class BulletController : Behavior
    {
        #region Behavior
        private void Update()
        {
            Singleton.BulletManager.onUpdate(Time.deltaTime);
        }
        #endregion
    }
}

