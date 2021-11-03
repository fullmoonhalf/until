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
        /// コマンドの実行
        /// </summary>
        /// <returns>true: 次のコマンドを実行する</returns>
        public bool execute(float elapsed);
    }
}
