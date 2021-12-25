using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.modules.gamemaster;
using until.modules.astral;
using until.utils;

namespace until.test
{
    [DefaultExecutionOrder(system.defines.ExecutionOrder.Undefined)]
    public class SubstanceCharacter : Substance
    {
        #region Inspector
        [SerializeField]
        private GameEntityIdentifiable _Identifier = GameEntityIdentifiable.Invalid;
        [SerializeField]
        private CharacterID _CharacterId = CharacterID.Invalid;
        #endregion

        #region Fields.
        /// <summary>GameEntiryIdentifier のスクリプト側からの参照</summary>
        public GameEntityIdentifier GameIdentifier
        {
            get
            {
                if (_GameIdentifier == null)
                {
                    var attribute = _Identifier.getAttrubute<GameEntityIdentifierValueAttribute>();
                    if (attribute != null)
                    {
                        _GameIdentifier = attribute.createGameEntityIdentifier();
                    }
                }
                return _GameIdentifier;
            }
        }
        private GameEntityIdentifier _GameIdentifier = null;

        /// <summary>CharacterID のスクリプト側からの参照</summary>
        public CharacterID CharacterID => _CharacterId;

        /// <summary>AstralBody への参照</summary>
        private AstralBody _RefAstralBody = null;
        #endregion

        #region Astral との接合
        public void bind(AstralBody body)
        {
            _RefAstralBody = body;
        }
        #endregion


    }
}

