using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.astral
{
    public interface AstralAction : AstralInterceptedable
    {
        /// <summary>アクション開始時</summary>
        public void onAstralActionStart(AstralSpritable sprite);
        /// <summary>アクション更新時処理</summary>
        /// <returns>アクションを継続する場合は true を返す</returns>
        public bool onAstralActionUpdate(AstralSpritable sprite, float delta_time);
        /// <summary>アクション終了時</summary>
        public void onAstralActionEnd(AstralSpritable sprite);
        /// <summary>次のアクションを取得する</summary>
        public AstralAction getNextAstralAction(AstralSpritable spritable);
        /// <summary>ワープ移動が発生した場合</summary>
        public void onAstralWarp(AstralSpritable spritable, Vector3 position);
    }
}
