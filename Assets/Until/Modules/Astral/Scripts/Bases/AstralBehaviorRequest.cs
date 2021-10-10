using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.astral
{
    public class AstralBehaviorRequestArgument
    {
    }

    public class AstralBehaviorRequest
    {
        public AstralBehaviorOperation Identifier;
        public event Action onAcceptEvent;
        public event Action onRejectedEvent;
        public event Action onCompeletedEvent;
        public AstralBehaviorRequestArgument Argument = null;


        /// <summary>
        /// コンストラクタ
        /// </summary>
        [Obsolete("Do not use default constructor.", true)]
        public AstralBehaviorRequest()
        {
        }

        /// <summary>
        /// リクエスト引数付きコンストラクタ
        /// </summary>
        /// <param name="argument"></param>
        public AstralBehaviorRequest(AstralBehaviorRequestArgument argument)
        {
            Argument = argument;
        }


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
