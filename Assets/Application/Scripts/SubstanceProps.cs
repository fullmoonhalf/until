using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.modules.gamefield;


namespace until.test
{
    [DefaultExecutionOrder(until.system.settings.UntilBehaviorOrder.GameField_Substance)]
    public class SubstanceProps : Substance
    {
        #region Inspector
        [SerializeField]
        private PropsID _PropsID = PropsID.Invalid;
        #endregion

        #region Fields.
        /// <summary>CharacterID �̃X�N���v�g������̎Q��</summary>
        public PropsID PropsID => _PropsID;
        /// <summary>�ʒu</summary>
        private Vector3 _Position = Vector3.zero;
        #endregion

        #region Methods.
        #region Substance
        public override Vector3 Position
        {
            get => _Position;
            set
            {
                _Position = value;
                gameObject.transform.position = _Position;
            }
        }

        protected override void onWarp(Vector3 position)
        {
        }
        #endregion
        #endregion
    }
}

