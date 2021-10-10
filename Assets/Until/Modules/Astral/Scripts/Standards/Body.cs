using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace until.modules.astral.standard
{
    public class Body : AstralBody
    {
        #region Fields.
        private HashSet<AstralBehaviorOperation> _ActiveBehavior = new HashSet<AstralBehaviorOperation>();
        #endregion


        #region Methods
        public Body(int id)
            : base(id)
        {
        }

        #region AstralElement
        public override void requestBehaviorStart(AstralBehaviorRequest request)
        {
            _ActiveBehavior.Add(request.Identifier);
            request.notifyAccept();
            request.notifyComplete();
        }

        public override void requestBehaviorEnd(AstralBehaviorRequest request)
        {
            _ActiveBehavior.Remove(request.Identifier);
            request.notifyAccept();
            request.notifyComplete();
        }

        public override AstralBehaviorStatus checkBehavior(AstralBehaviorOperation identifier)
        {
            return _ActiveBehavior.Contains(identifier) ? AstralBehaviorStatus.Active : AstralBehaviorStatus.Inactive;
        }
        #endregion
        #endregion
    }
}
