using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.modules.gamefield;


namespace until.test
{
    [DefaultExecutionOrder(system.defines.ExecutionOrder.Undefined)]
    public class AppSubstanceCharacter : Substance
    {
        #region Inspector
        [SerializeField]
        private CharacterID _CharacterId = CharacterID.Invalid;
        #endregion

        #region Fields.
        /// <summary>CharacterID �̃X�N���v�g������̎Q��</summary>
        public CharacterID CharacterID => _CharacterId;
        #endregion
    }
}

