using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;


namespace until.modules.bullet
{
    [DefaultExecutionOrder(until.system.settings.UntilBehaviorOrder.Bullet_BulletController)]
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

