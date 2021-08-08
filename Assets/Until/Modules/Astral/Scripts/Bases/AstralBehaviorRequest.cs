using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.astral
{
    public class AstralBehaviorRequest
    {
        #region definition
        #endregion

        #region Properties
        public AstralBehaviorIdentifier Identifier = AstralBehaviorIdentifier.NOP;
        public event Action OnAccepted = null;
        public event Action OnRejected = null;
        public event Action OnCompeleted = null;
        #endregion

        #region Methods
        #endregion
    }
}
