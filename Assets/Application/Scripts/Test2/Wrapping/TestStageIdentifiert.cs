using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.modules.gamefield;


namespace until.test2
{
    public class TestStageIdentifier : StageIdentifier
    {
        #region プロパティ
        public IdentifierStage Stage { get; private set; } = IdentifierStage.Invalid;
        #endregion

        #region コンストラクタ
        [Obsolete]
        public TestStageIdentifier()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="stage"></param>
        public TestStageIdentifier(IdentifierStage stage)
        {
            Stage = stage;
        }

        /// <summary>
        /// コピーコンストラクタ
        /// </summary>
        /// <param name="source"></param>
        public TestStageIdentifier(TestStageIdentifier source)
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
            if (other is TestStageIdentifier identifier)
            {
                return Stage == identifier.Stage;
            }
            return false;
        }
        #endregion
    }
}
