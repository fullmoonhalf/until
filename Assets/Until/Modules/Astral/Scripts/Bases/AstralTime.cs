using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.astral
{
    public class AstralTime
    {
        #region Properties
        public int Epoch
        {
            get => _Epoch;
        }
        #endregion

        #region Fields.
        private int _Epoch = 0;
        #endregion

        #region Methods.
        public AstralTime(int epoch)
        {
            _Epoch = epoch;
        }
        #endregion
    }
}

