using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.develop;


namespace until.modules.bullet.command
{
    [Serializable]
    public class BulletEmitCommandBulletEmitRelativeUniformLinearMotion : BulletEmitCommand
    {
        #region Parameters
        public string BulletName = "";
        public Vector3 Speed = Vector3.zero;
        public float Life = float.MaxValue;
        #endregion

        #region Constructor
        public BulletEmitCommandBulletEmitRelativeUniformLinearMotion(string name, Vector3 speed, float life)
        {
            BulletName = name;
            Speed = speed;
            Life = life;
        }
        #endregion

        #region BulletEmitCommand
        public BulletEmidCommandMnemonic Mnemonic => BulletEmidCommandMnemonic.BulletAbsoluteUniformLinearMotion;

        public BulletEmitCommandContext createContext(BulletEmitContext context)
        {
            return new Context(this, context);
        }
        #endregion

        #region Context
        private class Context : BulletEmitCommandContext
        {
            private BulletEmitCommandBulletEmitRelativeUniformLinearMotion _Command = null;
            private BulletEmitContext _Context = null;

            public Context(BulletEmitCommandBulletEmitRelativeUniformLinearMotion command, BulletEmitContext context)
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

                var speed = _Context.Rotation * _Command.Speed;
                var animator = new BulletAnimatorUniformLinearMotion(speed, _Command.Life);
                bullet.startBullet(animator, _Context.Position);
                return true;
            }
        }
        #endregion
    }
}


