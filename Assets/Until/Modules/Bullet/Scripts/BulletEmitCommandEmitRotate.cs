using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.bullet.command
{
    [Serializable]
    public class BulletEmitCommandEmitRotate : BulletEmitCommand
    {
        #region Parameters
        public Quaternion Speed = Quaternion.identity;
        public float Life = 0.0f;
        #endregion

        #region Constructor
        public BulletEmitCommandEmitRotate(Quaternion speed, float life)
        {
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
            private BulletEmitContext _Context = null;
            private BulletEmitCommandEmitRotate _Command = null;
            private float _Age = 0.0f;

            public Context(BulletEmitCommandEmitRotate command, BulletEmitContext context)
            {
                _Command = command;
                _Context = context;
            }

            public bool execute(float elapsed)
            {
                _Context.Rotation *= Quaternion.Slerp(Quaternion.identity, _Command.Speed, elapsed);
                _Age += elapsed;
                return _Age >= _Command.Life;
            }
        }
        #endregion
    }
}


