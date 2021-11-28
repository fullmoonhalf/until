using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.bullet.command
{
    [Serializable]
    public class BulletEmitCommandEmitTranslate : BulletEmitCommand
    {
        #region Parameters
        public Vector3 Speed = Vector3.zero;
        public float Life = 0.0f;
        #endregion

        #region Constructor
        public BulletEmitCommandEmitTranslate(Vector3 speed, float life)
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
            private BulletEmitCommandEmitTranslate _Command = null;
            private float _Age = 0.0f;

            public Context(BulletEmitCommandEmitTranslate command, BulletEmitContext context)
            {
                _Command = command;
                _Context = context;
            }

            public bool execute(float elapsed)
            {
                _Context.Position += _Command.Speed * elapsed;
                _Age += elapsed;
                return _Age >= _Command.Life;
            }
        }
        #endregion
    }
}


