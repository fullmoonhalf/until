using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.astral
{
    public abstract class AstralBody : AstralElement
    {
        #region Fields.
        /// <summary>���݂̃A�N�V����</summary>
        private AstralAction _CurrentAction = null;
        #endregion

        #region Methods.
        public AstralBody(int id) : base(id)
        {
        }

        /// <summary>
        /// �X�V����
        /// </summary>
        public void onAstralUpdate()
        {
            if (_CurrentAction != null)
            {
                if (!_CurrentAction.onAstralUpdate())
                {
                    _CurrentAction = null;
                }
            }
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

