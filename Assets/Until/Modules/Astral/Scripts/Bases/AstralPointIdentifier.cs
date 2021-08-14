using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;



namespace until.modules.astral
{
    public class AstralPointIdentifier : Identifier<AstralPointIdentifier>
    {
        #region definition
        public static readonly AstralPointIdentifier ORIGIN = new AstralPointIdentifier(0, 0);
        #endregion

        #region Properties
        public override int Hashcode => _Hashcode;
        public int SpaceID { get; private set; } = 0;
        public int PointID { get; private set; } = 0;
        #endregion

        #region Fields.
        private int _Hashcode = 0;
        #endregion

        #region Methods
        public AstralPointIdentifier()
        {
        }

        public AstralPointIdentifier(int space, int point)
        {
            SpaceID = space;
            PointID = point;
            _Hashcode = SpaceID.GetHashCode() ^ PointID.GetHashCode();
        }

        /// <summary>
        /// “™‰¿•]‰¿
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public override bool equal(AstralPointIdentifier identifier)
        {
            return SpaceID == identifier.SpaceID && PointID == identifier.PointID;
        }
        #endregion
    }
}
