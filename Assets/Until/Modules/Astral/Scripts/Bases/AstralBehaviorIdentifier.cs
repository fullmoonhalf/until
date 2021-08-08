using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.astral
{
    public class AstralBehaviorIdentifier
    {
        #region definition
        public static readonly AstralBehaviorIdentifier NOP = new AstralBehaviorIdentifier(0, 0);
        #endregion

        #region Properties
        public int CategoryID { get; private set; } = 0;
        public int ActionID { get; private set; } = 0;
        #endregion

        #region Methods
        public AstralBehaviorIdentifier()
        {
        }

        public AstralBehaviorIdentifier(int category, int action)
        {
            CategoryID = category;
            ActionID = action;
        }

        /// <summary>
        /// �����]��
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is AstralBehaviorIdentifier identifier)
            {
                return equals(identifier);
            }
            return false;
        }

        /// <summary>
        /// �����]��
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        private bool equals(AstralBehaviorIdentifier identifier)
        {
            return CategoryID == identifier.CategoryID && ActionID == identifier.ActionID;
        }

        /// <summary>
        /// �n�b�V���R�[�h�̎擾
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return CategoryID.GetHashCode() ^ ActionID.GetHashCode();
        }
        #endregion
    }
}
