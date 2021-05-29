using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.astral
{
    /// <summary>
    /// グラマー。次の思考を決める処理。
    /// </summary>
    public abstract class AstralGlamour
    {
        public abstract AstralAction getNextAction();
    }
}

