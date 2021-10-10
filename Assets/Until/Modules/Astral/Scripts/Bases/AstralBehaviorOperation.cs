using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;


namespace until.modules.astral
{
    public class AstralBehaviorOperation : Identifier<AstralBehaviorOperation>
    {
        #region definition
        public static readonly AstralBehaviorOperation NOP = new AstralBehaviorOperation(0, 0);
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
        public AstralBehaviorOperation()
        {
        }

        public AstralBehaviorOperation(int category, int action)
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
        public override bool equal(AstralBehaviorOperation identifier)
        {
            return CategoryID == identifier.CategoryID && ActionID == identifier.ActionID;
        }

        /// <summary>
        /// İ’è—p‚Ìˆø”‚Ì¶¬
        /// </summary>
        /// <returns></returns>
        public virtual AstralBehaviorRequestArgument createArgument()
        {
            return null;
        }
        #endregion
    }
}
