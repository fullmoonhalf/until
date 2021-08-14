using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.astral
{
    public class AstralBehaviorRequest
    {
        public AstralBehaviorIdentifier Identifier;
        public event Action onAccepted;
        public event Action onRejected;
        public event Action onCompeleted;
    }
}
