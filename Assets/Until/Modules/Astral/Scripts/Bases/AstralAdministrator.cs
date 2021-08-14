using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;
using until.modules.astral;


namespace until.singleton
{
    public class AstralAdministrator : Singleton<AstralAdministrator>
    {
        #region Fields.
        private AstralWorld _World = null;
        #endregion

        #region Methods.
        #region Singleton
        public override void onSingletonAwake()
        {
        }

        public override void onSingletonStart()
        {
        }

        public override void onSingletonDestroy()
        {
        }
        #endregion

        #region registration.
        public void regist(AstralWorld world)
        {
            _World = world;

        }
        #endregion

        #region process
        public void updateAstral()
        {
            if (_World != null)
            {
                _World.onAstralUpdate();
            }
        }
        #endregion
        #endregion
    }
}

