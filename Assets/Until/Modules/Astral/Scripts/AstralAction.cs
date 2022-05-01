using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.astral
{
    public interface AstralAction : AstralInterceptedable
    {
        /// <summary>�A�N�V�����J�n��</summary>
        public void onAstralActionStart(AstralSpritable sprite);
        /// <summary>�A�N�V�����X�V������</summary>
        /// <returns>�A�N�V�������p������ꍇ�� true ��Ԃ�</returns>
        public bool onAstralActionUpdate(AstralSpritable sprite, float delta_time);
        /// <summary>�A�N�V�����I����</summary>
        public void onAstralActionEnd(AstralSpritable sprite);
        /// <summary>���̃A�N�V�������擾����</summary>
        public AstralAction getNextAstralAction(AstralSpritable spritable);
        /// <summary>���[�v�ړ������������ꍇ</summary>
        public void onAstralWarp(AstralSpritable spritable, Vector3 position);
    }
}
