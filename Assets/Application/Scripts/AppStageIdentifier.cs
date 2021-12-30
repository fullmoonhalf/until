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
        public LevelID Stage { get; private set; } = LevelID.Invalid;
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
        public AppStageIdentifier(LevelID stage)
        {
            Stage = stage;
        }

        /// <summary>
        /// コピーコンストラクタ
        /// </summary>
        /// <param name="source"></param>
        public AppStageIdentifier(AppStageIdentifier source)
        {
            Stage = source.Stage;
        }
        #endregion

        #region object
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
