using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;


namespace until.modules.astral
{
    public class AstralManager : Singleton<AstralManager>
    {
        #region Definition
        private class InterfereContext
        {
            public AstralInterfereable Source { get; private set; }
            public AstralElement Target { get; private set; }

            public InterfereContext(AstralInterfereable source, AstralElement target)
            {
                Source = source;
                Target = target;
            }
        }
        #endregion

        #region Fields
        /// <summary>排他制御オブジェ</summary>
        private Object _LockObject = new Object();
        /// <summary>Element の集合</summary>
        private List<AstralElement> _ElementsCollection = new List<AstralElement>();
        /// <summaryインターフェアリスト</summary>
        private List<InterfereContext> _InterfereList = new List<InterfereContext>();
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
            _InterfereList.Clear();
        }
        #endregion

        #region Behavior
        public void onStart()
        {
        }

        public void onUpdate(float delta_time)
        {
            // interfere の処理
            foreach (var context in _InterfereList)
            {
                if (context.Target.onAstralInterceptTry(context.Source))
                {
                    context.Target.onAstralInterceptEstablished(context.Source);
                    context.Source.onAcceptInterference();
                }
                else
                {
                    context.Source.onRejectInterference();
                }
            }
            _InterfereList.Clear();

            // アップデートの更新
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

        #region Interfere
        public void interfere(AstralInterfereable interferer, AstralElement target)
        {
            lock (_LockObject)
            {
                _InterfereList.Add(new InterfereContext(interferer, target));
            }
        }
        #endregion
        #endregion
    }
}

