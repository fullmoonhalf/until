using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;


namespace until.modules.bullet
{
    public interface BulletAnimator
    {
        /// <summary>
        /// 開始時処理
        /// </summary>
        public void onBulletStart();

        /// <summary>
        /// 更新処理。
        /// </summary>
        /// <param name="elapsed">経過時間</param>
        /// <returns>keep alive: 今フレームで生存する場合trueを返す</returns>
        public bool onBulletUpdate(float elapsed);
        
        /// <summary>
        /// 弾の移動量
        /// </summary>
        /// <returns></returns>
        public Vector3 getDeltaBulletPosition();
    }
}

