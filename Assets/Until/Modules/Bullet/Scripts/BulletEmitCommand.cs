using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.bullet
{
    public enum BulletEmidCommandMnemonic
    {
        Nop,
        /// <summary>�e����: �Œ�_����̓��������^��/// </summary>
        BulletAbsoluteUniformLinearMotion,
        /// <summary>�e����: �G�~�b�^�[���W�n����̓��������^��/// </summary>
        BulletEmitRelativeUniformLinearMotion,
        /// <summary>�G�~�b�^�[�̈ʒu�ݒ�</summary>
        EmitSetTransform,
        /// <summary>�G�~�b�^�[�̈ړ�</summary>
        EmitTranslate,
        /// <summary>�G�~�b�^�[�̉�]</summary>
        EmitRotate,
        /// <summary>���s�[�g</summary>
        ControlRepeat,
        /// <summary>�^�C�}�[�X���[�v</summary>
        ControlSleep,
    }

    public interface BulletEmitCommand
    {
        public BulletEmidCommandMnemonic Mnemonic { get; }
        public BulletEmitCommandContext createContext(BulletEmitContext context);
    }

    public interface BulletEmitCommandContext
    {
        /// <summary>
        /// �R�}���h�̎��s
        /// </summary>
        /// <returns>true: ���̃R�}���h�����s����</returns>
        public bool execute(float elapsed);
    }
}
