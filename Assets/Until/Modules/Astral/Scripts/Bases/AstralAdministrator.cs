using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;
using until.modules.astral;


namespace until.modules.astral
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

        #region management.
        public void regist(AstralWorld world)
        {
            _World = world;

        }

        public AstralSpace getSpace(int id)
        {
            return _World.getSpace(id);
        }

        public AstralBody getBody(int id)
        {
            return _World.getBody(id);
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

