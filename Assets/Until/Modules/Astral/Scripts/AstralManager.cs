using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;


namespace until.modules.astral
{
    public class AstralManager : Singleton<AstralManager>
    {
        #region Fields
        /// <summary>Element の集合</summary>
        private List<AstralElement> _ElementsCollection = new List<AstralElement>();
        private Object _LockObject = new Object();
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
            _ElementsCollection.Clear();
        }
        #endregion

        #region Behavior
        public void onStart()
        {
        }

        public void onUpdate(float delta_time)
        {
            foreach (var element in _ElementsCollection)
            {
                element.onAstralUpdate(delta_time);
            }
        }

        public void onDestroy()
        {
        }
        #endregion

        #region Management
        public void regist(AstralElement element)
        {
            lock (_LockObject)
            {
                _ElementsCollection.Add(element);
            }
        }

        public void unregist(AstralElement element)
        {
            lock (_LockObject)
            {
                _ElementsCollection.Remove(element);
            }
        }
        #endregion
        #endregion
    }
}

