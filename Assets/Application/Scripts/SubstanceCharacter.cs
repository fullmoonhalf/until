using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.modules.gamemaster;
using until.utils;

namespace until.test
{
    [DefaultExecutionOrder(system.defines.ExecutionOrder.Undefined)]
    public class SubstanceCharacter : Substance
    {
        #region Inspector
        [SerializeField]
        private GameEntityIdentifiable _Identifier = GameEntityIdentifiable.Invalid;
        #endregion

        #region Fields.
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

