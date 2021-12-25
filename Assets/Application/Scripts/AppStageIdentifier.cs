using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.modules.gamefield;


namespace until.test
{
    public class AppStageIdentifier : StageIdentifier
    {
        #region プロパティ
        public StageID Stage { get; private set; } = StageID.Invalid;
        #endregion

        #region コンストラクタ
        [Obsolete]
        public AppStageIdentifier()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="stage"></param>
        public AppStageIdentifier(StageID stage)
        {
            Stage = stage;
        }

        public override string ToString()
        {
            return $"{base.ToString()}({Stage})";
        }

        #endregion


        #region StageIdentifier
        /// <summary>
        /// ハッシュコード
        /// </summary>
        public override int Hashcode => Stage.GetHashCode();

        /// <summary>
        /// 等価判断
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool equal(StageIdentifier other)
        {
            if (other is AppStageIdentifier identifier)
            {
                return Stage == identifier.Stage;
            }
            return false;
        }
        #endregion
    }
}
