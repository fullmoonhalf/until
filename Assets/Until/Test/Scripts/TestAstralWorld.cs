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
    public class TestAstralWorld : AstralWorld
    {
        #region Fields.
        private Dictionary<int, TestAstralSpace> _SpaceCollection = new Dictionary<int, TestAstralSpace>();
        private Dictionary<int, TestAstralBody> _BodyCollection = new Dictionary<int, TestAstralBody>();

        #endregion

        #region Methods
        #region AstralWorld
        public override AstralBody getBody(int id)
        {
            if (_BodyCollection.TryGetValue(id, out var body))
            {
                return body;
            }
            return null;
        }

        public override AstralSpace getSpace(int id)
        {
            if (_SpaceCollection.TryGetValue(id, out var space))
            {
                return space;
            }
            return null;
        }

        public override IEnumerable<AstralBody> getUpdatableBodies()
        {
            return _BodyCollection.Values;
        }

        public override AstralBody createBody(int id, string name = "")
        {
            var body = new TestAstralBody(id);
            _BodyCollection.Add(id, body);
            return body;
        }

        public override AstralSpace createSpace(int id, string name = "")
        {
            var space = new TestAstralSpace(id);
            _SpaceCollection.Add(id, space);
            return space;
        }
        #endregion
        #endregion
    }
}
#endif
