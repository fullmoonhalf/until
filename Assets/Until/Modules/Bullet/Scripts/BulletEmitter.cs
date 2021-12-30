//#define UNTIL_VERBOSE_MODULE_BULLET
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.develop;


namespace until.modules.bullet
{
    public class BulletEmitter
    {
        #region Definitions
        private class Context : BulletEmitContext
        {
            public Vector3 Position { get; set; } = Vector3.zero;
            public Quaternion Rotation { get; set; } = Quaternion.identity;
            public int ProgramCount { get; set; } = 0;
            public int RepeatCount { get; set; } = 0;
            public BulletParameter Parameter { get; set; } = null;
        }
        #endregion

        #region Fields
        private BulletEmitSpecifier _Specifier = null;
        private BulletEmitCommandContext _CurrentContext = null;
        private Context _Context = new Context();
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
#if UNTIL_VERBOSE_MODULE_BULLET
            Log.info(this, $"onUpdate({elapsed})");
#endif
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
                    if (_Context.ProgramCount >= _Specifier.Commands.Length)
                    {
                        keepAlive = false;
                        break;
                    }
                    var command = _Specifier.Commands[_Context.ProgramCount];
                    _CurrentContext = command.createContext(_Context);
#if UNTIL_VERBOSE_MODULE_BULLET
                    Log.info(this, $"PC={_Context.ProgramCount} {_CurrentContext.GetType().FullName}");
#endif
                    ++_Context.ProgramCount;
                }
            }
            return keepAlive;
        }
        #endregion
    }
}
