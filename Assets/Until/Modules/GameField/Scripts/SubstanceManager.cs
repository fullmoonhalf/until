using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;
using until.develop;
using until.modules.gamemaster;
using until.utils;


namespace until.modules.gamefield
{
    public class SubstanceManager : Singleton<SubstanceManager>
    {
        #region Properties
        #endregion

        #region Fields.
        private Dictionary<GameEntityIdentifier, List<Substance>> _SubstanceCollection = new Dictionary<GameEntityIdentifier, List<Substance>>();
        private Action _OnFinishToDestroyAll = null;
        #endregion

        #region Methods
        #region Singleton
        public override void onSingletonAwake()
        {
            _OnFinishToDestroyAll = null;
        }

        public override void onSingletonStart()
        {
        }

        public override void onSingletonDestroy()
        {
            _SubstanceCollection.Clear();
        }
        #endregion

        #region Behavior
        public void onStart()
        {
        }

        public void onUpdate()
        {
            procDestroyAll();
        }

        public void onDestroy()
        {
        }
        #endregion

        #region Request
        public bool requestToCreate(GameEntityIdentifiable classification, GameEntityIdentifier individual, Vector3 position)
        {
            var attribute = classification.getAttrubute<GameEntityIdentifierValueAttribute>();
            if (attribute == null)
            {
                Log.error(this, $"{nameof(requestToCreate)} is failed: {classification}'s GameEntityIdentifierValueAttribute is not found.");
                return false;
            }

            var name = attribute.Value.ToString();
            Singleton.PrefabInstantiateMediator.requestFromCollection(name,
                (result, obj) =>
                {
                    if (result != PrefabInstantiateMediator.Result.Success)
                    {
                        Log.error(this, $"{nameof(requestToCreate)} is failed: instantiate error {result}");
                        return;
                    }

                    if (obj is GameObject go)
                    {
                        go.transform.position = position;
                        var substance = go.GetComponent<Substance>();
                        if (substance != null)
                        {
                            if (individual != null)
                            {
                                substance.setIndividualIdentifier(individual);
                            }
                            regist(substance.IndividualIdentifier, substance);
                        }
                    }
                }
                , true);
            return true;
        }

        /// <summary>
        /// 全破棄
        /// </summary>
        public void requestToDestroyAll(Action onFinish)
        {
            if (onFinish != null)
            {
                _OnFinishToDestroyAll += onFinish;
            }
            else if (_OnFinishToDestroyAll == null)
            {
                _OnFinishToDestroyAll += Constant.NO_ACTION;
            }
        }

        /// <summary>
        /// 全破棄実行
        /// </summary>
        private void procDestroyAll()
        {
            if (_OnFinishToDestroyAll == null)
            {
                return;
            }
            if (Singleton.PrefabInstantiateMediator.IsBusy)
            {
                return;
            }
            foreach (var list in _SubstanceCollection.Values)
            {
                foreach (var substance in list)
                {
                    var go = substance.gameObject;
                    GameObject.Destroy(go);
                }
            }
            _SubstanceCollection.Clear();
            _OnFinishToDestroyAll();
            _OnFinishToDestroyAll = null;
        }
        #endregion

        #region Management
        /// <summary>
        /// 登録まわり
        /// </summary>
        /// <param name="substance"></param>
        public void regist(GameEntityIdentifier identifier, Substance substance)
        {
            if (_SubstanceCollection.TryGetValue(identifier, out var list) == false)
            {
                list = new List<Substance>();
                _SubstanceCollection.Add(identifier, list);
            }
            list.Add(substance);
        }

        /// <summary>
        /// 登録削除
        /// </summary>
        /// <param name="substance"></param>
        public void unregist(GameEntityIdentifier identifier)
        {
            _SubstanceCollection.Remove(identifier);
        }

        /// <summary>
        /// 該当識別子の Substance を取得する
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public Substance get(GameEntityIdentifier identifier)
        {
            if (_SubstanceCollection.TryGetValue(identifier, out var list))
            {
                if (list.Count > 0)
                {
                    return list[0];
                }
            }
            return null;
        }

        /// <summary>
        /// 該当識別子の Substance を全て取得する
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public Substance[] getAll(GameEntityIdentifier identifier)
        {
            if (_SubstanceCollection.TryGetValue(identifier, out var list))
            {
                if (list.Count > 0)
                {
                    return list.ToArray();
                }
            }
            return null;
        }
        #endregion
        #endregion
    }
}

