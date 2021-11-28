using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.develop;


namespace until.modules.bullet.command
{
    [Serializable]
    public class BulletEmitCommandBulletEmitRelativeHomingMotion : BulletEmitCommand
    {
        #region Parameters
        public string BulletName = "";
        public string TargetName = "";
        public float Speed = 0.0f;
        public float Life = float.MaxValue;
        #endregion

        #region Constructor
        public BulletEmitCommandBulletEmitRelativeHomingMotion(string bullet_name, string target_name, float speed, float life)
        {
            BulletName = bullet_name;
            TargetName = target_name;
            Speed = speed;
            Life = life;
        }
        #endregion

        #region BulletEmitCommand
        public BulletEmitCommandContext createContext(BulletEmitContext context)
        {
            return new Context(this, context);
        }
        #endregion

        #region Context
        private class Context : BulletEmitCommandContext
        {
            private BulletEmitCommandBulletEmitRelativeHomingMotion _Command = null;
            private BulletEmitContext _Context = null;

            public Context(BulletEmitCommandBulletEmitRelativeHomingMotion command, BulletEmitContext context)
            {
                _Command = command;
                _Context = context;
            }

            public bool execute(float elapsed)
            {
                var bullet = Singleton.BulletManager.rent(_Command.BulletName);
                if (bullet == null)
                {
                    return true;
                }
                var target = Singleton.BulletManager.getTarget(_Command.TargetName);
                if (target == null)
                {
                    return true;
                }

                var animator = new BulletAnimatorHomingMotion(bullet, target, _Command.Speed, _Command.Life);
                bullet.startBullet(animator, _Context.Position);
                return true;
            }
        }
        #endregion
    }
}


