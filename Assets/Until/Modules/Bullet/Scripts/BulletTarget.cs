using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.system;


namespace until.modules.bullet
{
    public abstract class BulletTarget : Behavior
    {
        public abstract void onContactBullet(BulletClient bullet);
        public abstract Vector3 BulletTargetPosotion { get; }
        public abstract string BulletTargetIdentifier { get; }

        #region Behavior
        protected virtual void Start()
        {
            Singleton.BulletManager.regist(this);
        }

        protected virtual void OnDestroy()
        {
            Singleton.BulletManager.unregist(this);
        }
        #endregion
    }
}
