using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace until.modules.astral.standard
{
    public class Spot : AstralSpot
    {
        #region Properties
        public string Name { get; private set; } = "";
        #endregion

        #region Methods
        public Spot(int id)
            : base(id)
        {
        }
        #endregion
    }
}
