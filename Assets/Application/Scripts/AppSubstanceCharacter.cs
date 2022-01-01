using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using until.modules.gamefield;
using until.modules.astral;

namespace until.test
{
    [DefaultExecutionOrder(until.system.settings.UntilBehaviorOrder.GameField_Substance)]
    public abstract class AppSubstanceCharacter : Substance
    {
        #region Definition
        public abstract AppAstralActionCogitation OriginCongitation { get; }
        #endregion

        #region Inspector
        [SerializeField]
        private CharacterID _CharacterId = CharacterID.Invalid;
        #endregion

        #region Fields.
        /// <summary>CharacterID への参照</summary>
        public CharacterID CharacterID => _CharacterId;
        /// <summary>AstralElement</summary>
        private AstralElement _AstralElement = null;
        /// <summary>位置</summary>
        private Vector3 _Position = Vector3.zero;
        /// <summary>ナビエージェントへの参照</summary>
        public NavMeshAgent RefNavMeshAgent { get; private set; } = null;
        /// <summary>所属グループ</summary>
        private AppAstralSquad _BelongGroup = null;
        #endregion

        #region Methods
        #region Behavior
        protected virtual void Start()
        {
            RefNavMeshAgent = gameObject.GetComponent<NavMeshAgent>();
            if (RefNavMeshAgent != null)
            {
                RefNavMeshAgent.isStopped = true;
                RefNavMeshAgent.updatePosition = false;
                RefNavMeshAgent.updateRotation = false;
            }

            _AstralElement = new AstralElement(OriginCongitation);
            Singleton.AstralManager.regist(_AstralElement);
        }

        protected virtual void OnDestroy()
        {
            Singleton.AstralManager.unregist(_AstralElement);
            _AstralElement = null;
        }
        #endregion

        #region Control
        public override Vector3 Position
        {
            get => _Position;
            set
            {
                _Position = value;
                gameObject.transform.position = value;
            }
        }

        protected override void onWarp(Vector3 position)
        {
            _AstralElement.onWarp(position);
        }

        public void bind(AppAstralSquad group)
        {
            _BelongGroup = group;
            OriginCongitation.bind(group);
        }
        #endregion

        #region Interfere
        public void interfere(AstralInterfereable interferer)
        {
            if (_AstralElement != null)
            {
                Singleton.AstralManager.interfere(interferer, _AstralElement);
            }
        }
        #endregion
        #endregion
    }
}

