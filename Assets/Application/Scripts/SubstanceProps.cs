using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.modules.gamefield;


namespace until.test
{
    [DefaultExecutionOrder(system.defines.ExecutionOrder.Undefined)]
    public class SubstanceProps : Substance
    {
        #region Inspector
        [SerializeField]
        private PropsID _PropsID = PropsID.Invalid;
        #endregion

        #region Fields.
        /// <summary>CharacterID �̃X�N���v�g������̎Q��</summary>
        public PropsID PropsID => _PropsID;
        #endregion
    }
}

