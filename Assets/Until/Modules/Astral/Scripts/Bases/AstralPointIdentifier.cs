using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.astral
{
    public class AstralPointIdentifier
    {
        #region definition
        public static readonly AstralPointIdentifier ORIGIN = new AstralPointIdentifier(0, 0);
        #endregion

        #region Properties
        public int SpaceID { get; private set; } = 0;
        public int PointID { get; private set; } = 0;
        #endregion

        #region Methods
        public AstralPointIdentifier()
        {
        }

        public AstralPointIdentifier(int space, int point)
        {
            SpaceID = space;
            PointID = point;
        }

        /// <summary>
        /// 等価評価
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is AstralPointIdentifier identifier)
            {
                return equals(identifier);
            }
            return false;
        }

        /// <summary>
        /// 等価評価
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        private bool equals(AstralPointIdentifier identifier)
        {
            return SpaceID == identifier.SpaceID && PointID == identifier.PointID;
        }

        /// <summary>
        /// ハッシュコードの取得
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode() ^ SpaceID.GetHashCode() ^ PointID.GetHashCode();
        }

        #endregion

    }
}
