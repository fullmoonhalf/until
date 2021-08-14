using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.astral
{
    public class AstralBehaviorRequest
    {
        public AstralBehaviorIdentifier Identifier;
        public event Action onAcceptEvent;
        public event Action onRejectedEvent;
        public event Action onCompeletedEvent;


        public void notifyAccept()
        {
            if (onAcceptEvent != null)
            {
                onAcceptEvent.Invoke();
            }
        }

        public void notifyReject()
        {
            if (onRejectedEvent != null)
            {
                onRejectedEvent.Invoke();
            }
        }

        public void notifyComplete()
        {
            if (onCompeletedEvent != null)
            {
                onCompeletedEvent.Invoke();
            }
        }
    }
}
