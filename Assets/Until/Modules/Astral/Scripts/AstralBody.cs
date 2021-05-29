using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.astral
{
    public abstract class AstralBody
    {
        #region Interfaces.
        /// <summary>���݂̃O���}�[</summary>
        protected abstract AstralGlamour CurrentGlamour { get; }
        #endregion

        #region Fields.
        /// <summary>���݂̃A�N�V����</summary>
        private AstralAction _CurrentAction = null;
        #endregion

        #region Methods.
        /// <summary>
        /// �X�V����
        /// </summary>
        public void onAstralUpdate()
        {
            if (_CurrentAction == null)
            {
                if (CurrentGlamour != null)
                {
                    _CurrentAction = CurrentGlamour.getNextAction();
                }
            }
            if (_CurrentAction != null)
            {
                if (!_CurrentAction.onAstralUpdate())
                {
                    _CurrentAction = null;
                }
            }
        }
        #endregion



    }
}

