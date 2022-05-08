using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.modules.gamefield;


namespace until.test2
{
    public class TestStageIdentifier : StageIdentifier
    {
        #region �v���p�e�B
        public IdentifierStage Stage { get; private set; } = IdentifierStage.Invalid;
        #endregion

        #region �R���X�g���N�^
        [Obsolete]
        public TestStageIdentifier()
        {
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="stage"></param>
        public TestStageIdentifier(IdentifierStage stage)
        {
            Stage = stage;
        }

        /// <summary>
        /// �R�s�[�R���X�g���N�^
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
        /// �n�b�V���R�[�h
        /// </summary>
        public override int Hashcode => Stage.GetHashCode();

        /// <summary>
        /// �������f
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
