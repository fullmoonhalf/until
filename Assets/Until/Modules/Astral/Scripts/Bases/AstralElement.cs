using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace until.modules.astral
{
    public abstract class AstralElement
    {
        #region Properties
        public int ID { get; private set; }
        public string Name { get; set; }
        public AstralPointIdentifier Point { get; protected set; } = AstralPointIdentifier.ORIGIN;
        #endregion

        #region Methos
        public AstralElement(int id)
        {
            ID = id;
        }


        public abstract void requestBehaviorStart(AstralBehaviorRequest request);
        public abstract void requestBehaviorEnd(AstralBehaviorRequest request);
        public abstract AstralBehaviorStatus checkBehavior(AstralBehaviorIdentifier identifier);
        #endregion
    }
}
