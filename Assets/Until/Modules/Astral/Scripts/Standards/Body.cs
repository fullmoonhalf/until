using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace until.modules.astral.standard
{
    public class Body : AstralBody
    {
        #region fields.
        protected override AstralGlamour CurrentGlamour => null;
        #endregion

        #region Methods
        public Body(int id)
            : base(id)
        {

        }

        #endregion
    }
}
