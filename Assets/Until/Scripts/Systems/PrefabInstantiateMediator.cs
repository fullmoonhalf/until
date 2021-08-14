using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.develop;
using until.system;


namespace until.system
{
    public class PrefabInstantiateMediator : Singleton<PrefabInstantiateMediator>
    {
        #region Definitions
        public enum Result
        {
            Success,
            Failure,
        }

        public delegate void OnFinishAction(Result result, UnityEngine.Object generatedObject);

        private class Request
        {
            public UnityEngine.Object Prefab = null;
            public OnFinishAction OnFinish = null;
            public bool Eternal = false;
        }
        #endregion

        #region Fields.
        private List<Request> _RequestList = new List<Request>();
        #endregion

        #region Singleton
        public override void onSingletonAwake()
        {
        }

        public override void onSingletonStart()
        {
        }

        public override void onSingletonDestroy()
        {
            _RequestList.Clear();
        }
        #endregion

        #region Process
        public void onUpdate()
        {
            process();
        }
        #endregion

        #region Request
        public void request(UnityEngine.Object prefab, OnFinishAction OnFinish = null, bool Eternal = false)
        {
            var Order = new Request();
            Order.Prefab = prefab;
            Order.OnFinish = OnFinish;
            Order.Eternal = Eternal;

            lock (_RequestList)
            {
                _RequestList.Add(Order);
            }

            Log.info(this, $"requested {prefab.name}");
        }

        public void request(string ResourceName, OnFinishAction onFinish = null, bool Eternal = false)
        {
            var Prefab = Resources.Load(ResourceName);
            request(Prefab, onFinish, Eternal);
        }
        #endregion

        #region Execution
        private void process()
        {
            foreach (var Request in _RequestList)
            {
                var GeneratedObject = GameObject.Instantiate(Request.Prefab);
                if (Request.Eternal)
                {
                    GameObject.DontDestroyOnLoad(GeneratedObject);
                }
                Request.OnFinish?.Invoke(Result.Success, GeneratedObject);
                Log.info(this, $"generated {Request.Prefab.name}");
            }
            _RequestList.Clear();
        }
        #endregion
    }
}

