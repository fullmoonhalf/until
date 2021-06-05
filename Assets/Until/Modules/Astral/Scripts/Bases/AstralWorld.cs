using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace until.modules.astral
{
    public abstract class AstralWorld
    {
        #region Definitions
        public abstract AstralSpace getSpace(int id);
        public abstract AstralSpot getSpot(int id);
        public abstract AstralBody getBody(int id);
        public abstract IEnumerable<AstralBody> getUpdatableBodies();
        #endregion



        #region Methods.
        public void onAstralUpdate()
        {
            var bodies = getUpdatableBodies();
            foreach (var body in bodies)
            {
                body.onAstralUpdate();
            }
        }
        #endregion
    }
}

