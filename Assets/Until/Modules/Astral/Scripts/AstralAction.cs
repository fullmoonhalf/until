using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.astral
{
    public interface AstralAction
    {
        /// <summary>�A�N�V�����J�n��</summary>
        public void onAstralActionStart();
        /// <summary>�A�N�V�����X�V������</summary>
        /// <returns>�A�N�V�������p������ꍇ�� true ��Ԃ�</returns>
        public bool onAstralActionUpdate(float delta_time);
        /// <summary>�A�N�V�����I����</summary>
        public void onAstralActionEnd();
        /// <summary>���̃A�N�V�������擾����</summary>
        public AstralAction getNextAstralAction();
#if false
        /// <summary>�A�N�V���������荞�݂��\���ǂ���</summary>
        public bool isAstralActionTrapable();
        /// <summary>�A�N�V���������荞�݂����������ꍇ�̏���</summary>
        public void onAstralActionTrapped();
        /// <summary>�A�N�V�����㊄�荞�݂��\���ǂ���</summary>
        public void onAstralActionInterrupted();
        /// <summary>�A�N�V�����㊄�荞�݂����������ꍇ�̏���</summary>
        public bool isAstralActionInterruptable();
#endif
    }
}
