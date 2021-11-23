using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.develop;


namespace until.modules.bullet.command
{
    [Serializable]
    public class BulletEmitCommandControlRepeat : BulletEmitCommand
    {
        #region Parameters
        public int Count = 0;
        public int RepeatIndex = 0;
        #endregion

        #region Constructor
        public BulletEmitCommandControlRepeat(int count, int repart_index = 0)
        {
            Count = count;
            RepeatIndex = repart_index;
        }
        #endregion

        #region BulletEmitCommand
        public BulletEmidCommandMnemonic Mnemonic => BulletEmidCommandMnemonic.ControlRepeat;

        public BulletEmitCommandContext createContext(BulletEmitContext context)
        {
            return new Context(this, context);
        }
        #endregion

        #region Context
        private class Context : BulletEmitCommandContext
        {
            private BulletEmitContext _Context = null;
            private BulletEmitCommandControlRepeat _Command = null;

            public Context(BulletEmitCommandControlRepeat command, BulletEmitContext context)
            {
                _Command = command;
                _Context = context;
            }

            public bool execute(float elapsed)
            {
                var end = _Context.RepeatCount >= _Command.Count;
                _Context.RepeatCount++;
                if (!end)
                {
                    _Context.ProgramCount = _Command.RepeatIndex;
                }
                return true;
            }
        }
        #endregion
    }
}


