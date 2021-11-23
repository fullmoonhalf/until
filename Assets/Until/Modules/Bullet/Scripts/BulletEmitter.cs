using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.bullet
{
    public class BulletEmitter
    {
        #region Fields
        private BulletEmitSpecifier _Specifier = null;
        private int _ProgramCounter = 0;
        private BulletEmitCommandContext _CurrentContext = null;
        #endregion

        #region Fields.
        public BulletEmitter(BulletEmitSpecifier specifier)
        {
            _Specifier = specifier;
        }


        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="elapsed">経過時間</param>
        /// <returns>次フレームも継続する場合は true</returns>
        public bool onUpdate(float elapsed)
        {
            var keepAlive = false;
            while (true)
            {
                if (_CurrentContext != null)
                {
                    var execute_next = _CurrentContext.execute(elapsed);
                    if (execute_next)
                    {
                        _CurrentContext = null;
                    }
                    else
                    {
                        // 現在のコマンドを続ける
                        keepAlive = true;
                        break;
                    }
                }
                if (_CurrentContext == null)
                {
                    if (_ProgramCounter >= _Specifier.Commands.Length)
                    {
                        keepAlive = false;
                        break;
                    }
                    var command = _Specifier.Commands[_ProgramCounter];
                    _CurrentContext = command.createContext();
                    ++_ProgramCounter;
                }
            }
            return keepAlive;
        }
        #endregion
    }
}
