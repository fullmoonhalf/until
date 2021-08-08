using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace until.modules.astral
{
    public class AstralSpace : AstralElement
    {
        #region Methos
        public AstralSpace(int id) : base(id)
        {
        }

        #region AstralElement
        public override void requestBehaviorStart(AstralBehaviorRequest request)
        {
        }

        public override void requestBehaviorEnd(AstralBehaviorRequest request)
        {
        }

        public override AstralBehaviorStatus checkBehavior(AstralBehaviorIdentifier identifier)
        {
            return AstralBehaviorStatus.Inactivating;
        }
        #endregion
        #endregion
    }
}
