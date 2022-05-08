using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.astral
{
    public abstract class AstralActionable<TypeAstralAction, TypeAstralSprite>
        where TypeAstralAction : AstralActionable<TypeAstralAction, TypeAstralSprite>
        where TypeAstralSprite : AstralSpritable<TypeAstralSprite>
    {
        /// <summary>�A�N�V�����J�n��</summary>
        public abstract void onAstralActionStart(TypeAstralSprite sprite);
        /// <summary>�A�N�V�����X�V������</summary>
        /// <returns>�A�N�V�������p������ꍇ�� true ��Ԃ�</returns>
        public abstract bool onAstralActionUpdate(TypeAstralSprite sprite, float delta_time);
        /// <summary>�A�N�V�����I����</summary>
        public abstract void onAstralActionEnd(TypeAstralSprite sprite);
        public abstract TypeAstralAction getNextAstralAction(TypeAstralSprite spritable);
        public abstract AstralInterceptResult onAstralInterceptTry(AstralInterfereable interferer);
        public abstract void onAstralInterceptEstablished(AstralInterfereable interferer);
    }
}
