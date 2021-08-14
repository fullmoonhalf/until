using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.astral
{
    public class AstralBehaviorIdentifier : IEquatable<AstralBehaviorIdentifier>
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

        #region 等価性判断処理
        /// <summary>
        /// 等価評価
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is AstralBehaviorIdentifier identifier)
            {
                return Equals(identifier);
            }
            return false;
        }

        /// <summary>
        /// 等価評価
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public bool Equals(AstralBehaviorIdentifier identifier)
        {
            return CategoryID == identifier.CategoryID && ActionID == identifier.ActionID;
        }

        /// <summary>
        /// ハッシュコードの取得
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return CategoryID.GetHashCode() ^ ActionID.GetHashCode();
        }


        public static bool operator ==(AstralBehaviorIdentifier lhs, AstralBehaviorIdentifier rhs)
        {
            if (lhs != null && rhs != null)
            {
                return lhs.Equals(rhs);
            }
            return false;
        }

        public static bool operator !=(AstralBehaviorIdentifier lhs, AstralBehaviorIdentifier rhs)
        {
            return !(lhs == rhs);
        }
        #endregion
        #endregion
    }
}
