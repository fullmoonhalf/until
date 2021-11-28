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
        /// コマンドの実行
        /// </summary>
        /// <returns>true: 次のコマンドを実行する</returns>
        public bool execute(float elapsed);
    }
}
