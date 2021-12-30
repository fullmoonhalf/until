using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.bullet.command
{
    [Serializable]
    public class BulletEmitCommandSystemSetParameter : BulletEmitCommand
    {
        #region Fields.
        public BulletParameter _Parameter { get; private set; }
        #endregion

        #region Constructor
        public BulletEmitCommandSystemSetParameter(BulletParameter parameter)
        {
            _Parameter = parameter;
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
            private BulletEmitCommandSystemSetParameter _Command = null;

            public Context(BulletEmitCommandSystemSetParameter command, BulletEmitContext context)
            {
                _Command = command;
                _Context = context;
            }

            public bool execute(float elapsed)
            {
                _Context.Parameter = _Command._Parameter;
                return true;
            }
        }
        #endregion
    }
}


