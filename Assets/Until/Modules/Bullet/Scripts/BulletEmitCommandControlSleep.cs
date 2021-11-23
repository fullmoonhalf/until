using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.bullet.command
{
    [Serializable]
    public class BulletEmitCommandControlSleep : BulletEmitCommand
    {
        #region Parameters
        public float _Life = 0.0f;
        #endregion

        #region Constructor
        public BulletEmitCommandControlSleep(float life)
        {
            _Life = life;
        }
        #endregion


        #region BulletEmitCommand
        public BulletEmidCommandMnemonic Mnemonic => BulletEmidCommandMnemonic.ControlSleep;

        public BulletEmitCommandContext createContext(BulletEmitContext context)
        {
            return new Context(this);
        }
        #endregion

        #region Context
        private class Context : BulletEmitCommandContext
        {
            private BulletEmitCommandControlSleep _Command = null;
            private float _Age = 0.0f;

            public Context(BulletEmitCommandControlSleep command)
            {
                _Command = command;
            }

            public bool execute(float elapsed)
            {
                var end = _Age >= _Command._Life;
                _Age += elapsed;
                return end;
            }
        }
        #endregion
    }
}


