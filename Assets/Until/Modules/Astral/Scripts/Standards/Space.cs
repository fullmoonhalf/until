using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace until.modules.astral.standard
{
    public class Space : AstralSpace
    {
        #region fields.
        private List<Spot> _SpotCollection = new List<Spot>();
        private List<Space> _SubSpaceCollection = new List<Space>();
        #endregion

        #region Methods
        public Space(int id)
            : base(id)
        {
            Point = new AstralPointIdentifier(id, 0);
        }

        #region Registration
        /// <summary>
        /// スポットの登録
        /// </summary>
        /// <param name="spot"></param>
        public void regist(Spot spot)
        {
            _SpotCollection.Add(spot);
        }

        /// <summary>
        /// サブスペース登録
        /// </summary>
        /// <param name="space"></param>
        public void regist(Space space)
        {
            _SubSpaceCollection.Add(space);
        }
        #endregion
        #endregion
    }
}

