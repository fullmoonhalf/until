using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.bullet
{
    public enum BulletEmidCommandMnemonic
    {
        Nop,
        /// <summary>弾発射: 固定点からの等速直線運動/// </summary>
        BulletAbsoluteUniformLinearMotion,
        /// <summary>弾発射: エミッター座標系からの等速直線運動/// </summary>
        BulletEmitRelativeUniformLinearMotion,
        /// <summary>エミッターの位置設定</summary>
        EmitSetTransform,
        /// <summary>エミッターの移動</summary>
        EmitTranslate,
        /// <summary>エミッターの回転</summary>
        EmitRotate,
        /// <summary>リピート</summary>
        ControlRepeat,
        /// <summary>タイマースリープ</summary>
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
        /// コマンドの実行
        /// </summary>
        /// <returns>true: 次のコマンドを実行する</returns>
        public bool execute(float elapsed);
    }
}
