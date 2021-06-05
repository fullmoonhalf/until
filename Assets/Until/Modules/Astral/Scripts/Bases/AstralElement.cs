using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace until.modules.astral
{
    public class AstralElement
    {
        #region Properties
        public int ID { get; private set; }
        public AstralPointIdentifier Point { get; protected set; } = AstralPointIdentifier.ORIGIN;
        #endregion

        #region Methos
        public AstralElement(int id)
        {
            ID = id;
        }
        #endregion
    }
}
