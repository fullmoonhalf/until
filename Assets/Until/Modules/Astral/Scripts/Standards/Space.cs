using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace until.modules.astral.standard
{
    public class Space : AstralSpace
    {
        #region fields.
        private List<AstralBody> _SpotCollection = new List<AstralBody>();
        private List<AstralSpace> _SubSpaceCollection = new List<AstralSpace>();
        #endregion

        #region Methods
        public Space(int id)
            : base(id)
        {
            Point = new AstralPointIdentifier(id, 0);
        }

        #region AstralElement
        public override void requestBehaviorStart(AstralBehaviorRequest request)
        {
        }

        public override void requestBehaviorEnd(AstralBehaviorRequest request)
        {
        }

        public override AstralBehaviorStatus checkBehavior(AstralBehaviorOperation identifier)
        {
            return AstralBehaviorStatus.Inactivating;
        }
        #endregion

        #region AstralSpace
        /// <summary>
        /// �{�f�B�̓o�^
        /// </summary>
        /// <param name="body"></param>
        public override void regist(AstralBody body)
        {
            _SpotCollection.Add(body);
        }

        /// <summary>
        /// �T�u�X�y�[�X�o�^
        /// </summary>
        /// <param name="space"></param>
        public override void regist(AstralSpace space)
        {
            _SubSpaceCollection.Add(space);
        }
        #endregion
        #endregion
    }
}

