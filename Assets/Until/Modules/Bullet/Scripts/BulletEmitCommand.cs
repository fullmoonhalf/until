using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.bullet
{
    public interface BulletEmitCommand
    {
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
