using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.astral
{
    public abstract class AstralBody : AstralElement
    {
        #region Defines
        public abstract void onAstralUpdate();
        #endregion

        #region Methods.
        public AstralBody(int id) : base(id)
        {
        }
        #endregion
    }
}

