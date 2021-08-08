using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.astral
{
    public enum AstralBehaviorStatus
    {
        /// <summary>非アクティブ状態</summary>
        Inactive,
        /// <summary>アクティブ状態への遷移中</summary>
        Activating,
        /// <summary>アクティブ状態</summary>
        Active,
        /// <summary>非アクティブ状態への遷移中</summary>
        Inactivating,
    }
}
