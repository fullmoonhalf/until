using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;
using until.modules.gamemaster;
using until.utils;


namespace until.modules.gamefield
{
    [DefaultExecutionOrder(system.defines.ExecutionOrder.Undefined)]
    public class Substance : Behavior
    {
        #region Inspector
        [SerializeField]
        private GameEntityIdentifiable _Identifier = GameEntityIdentifiable.Invalid;
        #endregion

        #region Properties
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
        #endregion
    }
}


