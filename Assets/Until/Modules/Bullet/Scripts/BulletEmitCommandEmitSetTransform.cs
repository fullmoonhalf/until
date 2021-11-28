using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.bullet.command
{
    [Serializable]
    public class BulletEmitCommandEmitSetTransform : BulletEmitCommand
    {
        #region Parameters
        public Vector3 Position = Vector3.zero;
        public Quaternion Rotation = Quaternion.identity;
        #endregion

        #region Constructor
        public BulletEmitCommandEmitSetTransform(Vector3 position, Quaternion rotation)
        {
            Position = position;
            Rotation = rotation;
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
            private BulletEmitCommandEmitSetTransform _Command = null;

            public Context(BulletEmitCommandEmitSetTransform command, BulletEmitContext context)
            {
                _Command = command;
                _Context = context;
            }

            public bool execute(float elapsed)
            {
                _Context.Position += _Command.Position;
                return true;
            }
        }
        #endregion
    }
}


