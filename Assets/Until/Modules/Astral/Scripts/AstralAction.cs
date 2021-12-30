using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.astral
{
    public interface AstralAction : AstralInterceptedable
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
    }
}
