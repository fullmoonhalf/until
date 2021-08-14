using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;


namespace until.modules.astral
{
    public class AstralBehaviorIdentifier : Identifier<AstralBehaviorIdentifier>
    {
        #region definition
        public static readonly AstralBehaviorIdentifier NOP = new AstralBehaviorIdentifier(0, 0);
        #endregion

        #region Properties
        public override int Hashcode => _Hashcode;
        public int CategoryID { get; private set; } = 0;
        public int ActionID { get; private set; } = 0;
        #endregion

        #region Fields.
        public int _Hashcode = 0;
        #endregion

        #region Methods
        public AstralBehaviorIdentifier()
        {
        }

        public AstralBehaviorIdentifier(int category, int action)
        {
            CategoryID = category;
            ActionID = action;
            _Hashcode = CategoryID.GetHashCode() ^ ActionID.GetHashCode();
        }

        /// <summary>
        /// “™‰¿•]‰¿
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public override bool equal(AstralBehaviorIdentifier identifier)
        {
            return CategoryID == identifier.CategoryID && ActionID == identifier.ActionID;
        }
        #endregion
    }
}
