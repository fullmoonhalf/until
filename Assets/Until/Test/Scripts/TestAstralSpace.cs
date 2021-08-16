#if TEST
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.develop;
using until.system;
using until.modules.astral;
using until.modules.gamemaster;

namespace until.test
{
    public class TestAstralSpace : AstralSpace
    {
        #region fields.
        private List<AstralBody> _SpotCollection = new List<AstralBody>();
        private List<AstralSpace> _SubSpaceCollection = new List<AstralSpace>();
        #endregion

        #region Methods
        public TestAstralSpace(int id)
            : base(id)
        {

        }

        #region AstralElement
        public override void requestBehaviorStart(AstralBehaviorRequest request)
        {
        }

        public override void requestBehaviorEnd(AstralBehaviorRequest request)
        {
        }

        public override AstralBehaviorStatus checkBehavior(AstralBehaviorIdentifier identifier)
        {
            return AstralBehaviorStatus.Inactivating;
        }
        #endregion

        #region AstralSpace
        /// <summary>
        /// ボディの登録
        /// </summary>
        /// <param name="body"></param>
        public override void regist(AstralBody body)
        {
            _SpotCollection.Add(body);
        }

        /// <summary>
        /// サブスペース登録
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
#endif
