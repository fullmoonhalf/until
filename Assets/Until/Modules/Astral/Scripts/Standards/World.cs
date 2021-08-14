using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.astral.standard
{
    public class World : AstralWorld
    {
        #region Properties
        #endregion

        #region Fields.
        private Dictionary<int, Space> _SpaceCollection = new Dictionary<int, Space>();
        private Dictionary<int, Body> _BodyCollection = new Dictionary<int, Body>();
        #endregion

        #region Methods
        #region AstralWorld
        public override AstralSpace getSpace(int id)
        {
            if (_SpaceCollection.TryGetValue(id, out var space))
            {
                return space;
            }
            return null;
        }

        public override AstralBody getBody(int id)
        {
            if (_BodyCollection.TryGetValue(id, out var body))
            {
                return body;
            }
            return null;
        }

        public override IEnumerable<AstralBody> getUpdatableBodies()
        {
            return _BodyCollection.Values;
        }
        #endregion

        #region Factory Methods.
        public Space createSpace(int id, string name = "")
        {
            var space = new Space(id);
            space.Name = name;
            _SpaceCollection.Add(id, space);
            return space;
        }

        public Body createBody(int id, string name = "")
        {
            var body = new Body(id);
            body.Name = name;
            _BodyCollection.Add(id, body);
            return body;
        }
        #endregion
        #endregion
    }
}
