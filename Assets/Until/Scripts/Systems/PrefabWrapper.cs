using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace until.system
{
    [Serializable]
    public class PrefabWrapper
    {
        #region Properties
        public UnityEngine.Object Prefab
        {
            get => _Prefab;
        }
        [SerializeField]
        private UnityEngine.Object _Prefab = null;
        #endregion

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
        public void instantiate(PrefabInstantiateMediator.OnFinishAction OnFinish = null, bool Eternal = false)
        {
            Singleton.PrefabInstantiateMediator.request(_Prefab, OnFinish, Eternal);
        }
        #endregion
    }
}

