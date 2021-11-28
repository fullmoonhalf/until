using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;
using until.utils;
using until.develop;


namespace until.modules.bullet
{
    public class BulletManager : Singleton<BulletManager>
#if TEST
        , DevelopIndicatorElement
#endif
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
        private Dictionary<string, BulletTarget> _TargetCollection = new Dictionary<string, BulletTarget>();
        private List<BulletEmitter> _EmitterList = new List<BulletEmitter>();
        private int _CurrentBulletCount = 0;
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
            destroyTargetCollection();
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

        #region Target Management
        public void regist(BulletTarget target)
        {
            lock (_TargetCollection)
            {
                _TargetCollection.Add(target.BulletTargetIdentifier, target);
            }
        }

        public void unregist(BulletTarget target)
        {
            lock (_TargetCollection)
            {
                _TargetCollection.Remove(target.BulletTargetIdentifier);
            }
        }

        public BulletTarget getTarget(string name)
        {
            lock (_TargetCollection)
            {
                if (_TargetCollection.TryGetValue(name, out var target))
                {
                    return target;
                }
            }
            return null;
        }

        private void destroyTargetCollection()
        {
            lock (_TargetCollection)
            {
                _TargetCollection.Clear();
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
                    ++_CurrentBulletCount;
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
                --_CurrentBulletCount;
            }
        }
        #endregion
        #endregion

#if TEST
        #region Indicator
        public string DevelopIndicatorText => _DevelopIndicatorText;
        public int DevelopIndicatorWidth => 300;
        public int DevelopIndicatorHeight => 40;
        private string _DevelopIndicatorText = "";

        public void onIndicatorUpdate()
        {
            _DevelopIndicatorText = $"[Bullet] bullet={_CurrentBulletCount}";
        }
        #endregion
#endif
    }
}

