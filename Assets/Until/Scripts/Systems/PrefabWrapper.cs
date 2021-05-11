using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace until.system
{
    [Serializable]
    public class PrefabWrapper
    {
        [SerializeField]
        private UnityEngine.Object _Prefab = null;

        #region コンストラクタ
        public PrefabWrapper()
        {
        }

        public PrefabWrapper(UnityEngine.Object prefab)
        {
            _Prefab = prefab;
        }
        #endregion

        #region 
        /// <summary>
        /// Instantiate
        /// </summary>
        /// <param name="OnFinish"></param>
        /// <param name="Eternal"></param>
        public void instantiate(singleton.PrefabInstantiateMediator.OnFinishAction OnFinish = null, bool Eternal = false)
        {
            singleton.PrefabInstantiateMediator.Instance.request(_Prefab, OnFinish, Eternal);
        }
        #endregion
    }
}

