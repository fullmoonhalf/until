using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace until.modules.astral
{
    public abstract class AstralSpace : AstralElement
    {
        #region 
        public abstract void regist(AstralBody body);
        public abstract void regist(AstralSpace space);
        #endregion


        #region Methos
        public AstralSpace(int id) : base(id)
        {
        }
        #endregion
    }
}
