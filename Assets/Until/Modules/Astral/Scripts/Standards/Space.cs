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
        /// �X�|�b�g�̓o�^
        /// </summary>
        /// <param name="spot"></param>
        public void regist(Spot spot)
        {
            _SpotCollection.Add(spot);
        }

        /// <summary>
        /// �T�u�X�y�[�X�o�^
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

