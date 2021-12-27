using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.modules.gamefield;
using until.modules.astral;

namespace until.test
{
    [DefaultExecutionOrder(system.defines.ExecutionOrder.Undefined)]
    public abstract class AppSubstanceCharacter : Substance
    {
        #region Definition
        protected abstract AstralAction getCogitationOrigin();
        #endregion

        #region Inspector
        [SerializeField]
        private CharacterID _CharacterId = CharacterID.Invalid;
        #endregion

        #region Fields.
        /// <summary>CharacterID �̃X�N���v�g������̎Q��</summary>
        public CharacterID CharacterID => _CharacterId;
        /// <summary>AstralElement</summary>
        private AstralElement _AstralElement = null;
        /// <summary>�ʒu</summary>
        private Vector3 _Position = Vector3.zero;
        #endregion

        #region Methods
        #region Behavior
        protected virtual void Start()
        {
            _AstralElement = new AstralElement(getCogitationOrigin()); // ��X�O������̋����ɐ؂�ւ��B
            Singleton.AstralManager.regist(_AstralElement);
        }

        protected virtual void OnDestroy()
        {
            Singleton.AstralManager.unregist(_AstralElement);
            _AstralElement = null;
        }
        #endregion

        #region ISA
        public Vector3 Position
        {
            get => _Position;
            set
            {
                _Position = value;
                gameObject.transform.position = _Position;
            }
        }
        #endregion
        #endregion
    }
}

