using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.bullet
{
    public enum BulletEmidCommandMnemonic
    {
        Nop,
        FixedLiner,
        End,
    }

    public interface BulletEmitCommand
    {
        public BulletEmidCommandMnemonic Mnemonic { get; }
        public BulletEmitCommandContext createContext();
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
