using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.bullet.command
{
    [Serializable]
    public class BulletEmitCommandBulletAbsoluteUniformLinearMotion : BulletEmitCommand
    {
        #region Parameters
        public string BulletName = "";
        public Vector3 StartPosition = Vector3.zero;
        public Vector3 Speed = Vector3.zero;
        public float Life = float.MaxValue;
        #endregion

        #region Constructor
        public BulletEmitCommandBulletAbsoluteUniformLinearMotion(string name, Vector3 start, Vector3 speed, float life)
        {
            BulletName = name;
            StartPosition = start;
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
            private BulletEmitCommandBulletAbsoluteUniformLinearMotion _Command = null;
            private BulletEmitContext _Context = null;

            public Context(BulletEmitCommandBulletAbsoluteUniformLinearMotion command, BulletEmitContext context)
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

                var animator = new BulletAnimatorUniformLinearMotion(_Command.Speed, _Command.Life);
                bullet.startBullet(animator, _Command.StartPosition, _Context.Parameter);
                return true;
            }
        }
        #endregion
    }
}


