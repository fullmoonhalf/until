using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.astral
{
    public interface AstralAction
    {
        /// <summary>アクション開始時</summary>
        public void onAstralActionStart();
        /// <summary>アクション更新時処理</summary>
        /// <returns>アクションを継続する場合は true を返す</returns>
        public bool onAstralActionUpdate(float delta_time);
        /// <summary>アクション終了時</summary>
        public void onAstralActionEnd();
        /// <summary>次のアクションを取得する</summary>
        public AstralAction getNextAstralAction();
#if false
        /// <summary>アクション中割り込みが可能かどうか</summary>
        public bool isAstralActionTrapable();
        /// <summary>アクション中割り込みが発生した場合の処理</summary>
        public void onAstralActionTrapped();
        /// <summary>アクション後割り込みが可能かどうか</summary>
        public void onAstralActionInterrupted();
        /// <summary>アクション後割り込みが発生した場合の処理</summary>
        public bool isAstralActionInterruptable();
#endif
    }
}
