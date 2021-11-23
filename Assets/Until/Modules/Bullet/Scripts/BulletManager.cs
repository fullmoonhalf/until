using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;
using until.utils;


namespace until.modules.bullet
{
    public class BulletManager : Singleton<BulletManager>
    {
        #region Defines
        private class BulletPool : Pool<BulletClient>
        {
            public BulletPool(BulletClient[] pool) : base(pool)
            {
            }
        }
        #endregion

        #region Fields.
        private Dictionary<string, BulletPool> _PoolCollection = new Dictionary<string, BulletPool>();
        private List<BulletEmitter> _EmitterList = new List<BulletEmitter>();
        #endregion

        #region Methods
        #region Singleton
        public override void onSingletonAwake()
        {
        }

        public override void onSingletonStart()
        {
        }

        public override void onSingletonDestroy()
        {
            destroyBulletPool();
        }

        public void onUpdate(float elapsed)
        {
            onUpdateEmitter(elapsed);
        }
        #endregion

        #region Pool Management
        /// <summary>
        /// プール生成
        /// </summary>
        /// <param name="order"></param>
        public void buildBulletPool(BulletPoolOrder order)
        {
            foreach (var specifier in order.SpecifierList)
            {
                var golist = new BulletClient[specifier.Count];
                for (int index = 0; index < specifier.Count; ++index)
                {
                    var go = Singleton.PrefabInstantiateMediator.requestFromCollection(specifier.PrefabName, eternal: true, immidiate: true);
                    if (go.TryGetComponent<BulletClient>(out var client))
                    {
                        golist[index] = client;
                    }
                }
                var pool = new BulletPool(golist);
                _PoolCollection[specifier.PrefabName] = pool;
            }
        }

        /// <summary>
        /// プール破棄
        /// </summary>
        public void destroyBulletPool()
        {
            foreach (var pool in _PoolCollection.Values)
            {
                pool.release(obj => GameObject.Destroy(obj));
            }
            _PoolCollection.Clear();
        }
        #endregion

        #region Emitter Management
        public void regist(BulletEmitter emitter)
        {
            lock (_EmitterList)
            {
                _EmitterList.Add(emitter);
            }
        }

        public void unregist(BulletEmitter emitter)
        {
            lock (_EmitterList)
            {
                _EmitterList.Remove(emitter);
            }
        }

        private void onUpdateEmitter(float elapsed)
        {
            lock (_EmitterList)
            {
                _EmitterList.RemoveAll(emitter => emitter.onUpdate(elapsed) == false);
            }
        }
        #endregion

        #region Request
        public BulletClient rent(string name)
        {
            if (_PoolCollection.TryGetValue(name, out var pool))
            {
                var client = pool.rent();
                if (client != null)
                {
                    Singleton.GameObjectControlMediator.requestSetEnable(client.gameObject, true);
                }
                return client;
            }
            return null;
        }


        public void back(BulletClient client)
        {
            if (_PoolCollection.TryGetValue(client.ButtleName, out var pool))
            {
                Singleton.GameObjectControlMediator.requestSetEnable(client.gameObject, false);
                pool.back(client);
            }
        }
        #endregion
        #endregion
    }
}

