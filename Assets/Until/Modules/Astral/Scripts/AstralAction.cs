using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.astral
{
    public abstract class AstralActionable<TypeAstralAction, TypeAstralSprite>
        where TypeAstralAction : AstralActionable<TypeAstralAction, TypeAstralSprite>
        where TypeAstralSprite : AstralSpritable<TypeAstralSprite>
    {
        /// <summary>アクション開始時</summary>
        public abstract void onAstralActionStart(TypeAstralSprite sprite);
        /// <summary>アクション更新時処理</summary>
        /// <returns>アクションを継続する場合は true を返す</returns>
        public abstract bool onAstralActionUpdate(TypeAstralSprite sprite, float delta_time);
        /// <summary>アクション終了時</summary>
        public abstract void onAstralActionEnd(TypeAstralSprite sprite);
        public abstract TypeAstralAction getNextAstralAction(TypeAstralSprite spritable);
        public abstract AstralInterceptResult onAstralInterceptTry(AstralInterfereable interferer);
        public abstract void onAstralInterceptEstablished(AstralInterfereable interferer);
    }
}
