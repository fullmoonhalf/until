using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace until.modules.astral.standard
{
    public class Space : AstralSpace
    {
        #region fields.
        private List<Body> _SpotCollection = new List<Body>();
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
        /// ボディの登録
        /// </summary>
        /// <param name="body"></param>
        public void regist(Body body)
        {
            _SpotCollection.Add(body);
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

