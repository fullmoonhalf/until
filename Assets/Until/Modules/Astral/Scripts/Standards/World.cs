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
        private Dictionary<int, Spot> _SpotCollection = new Dictionary<int, Spot>();
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

        public override AstralSpot getSpot(int id)
        {
            if (_SpotCollection.TryGetValue(id, out var spot))
            {
                return spot;
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
        public Space createSpace(int id)
        {
            var space = new Space(id);
            _SpaceCollection.Add(id, space);
            return space;
        }

        public Spot createSpot(int id)
        {
            var spot = new Spot(id);
            _SpotCollection.Add(id, spot);
            return spot;
        }

        public Body createBody(int id)
        {
            var body = new Body(id);
            _BodyCollection.Add(id, body);
            return body;
        }
        #endregion
        #endregion
    }
}
