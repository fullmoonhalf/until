using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;
using until.develop;


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
            var interferes = _InterfereList.ToArray();
            _InterfereList.Clear();
            foreach (var context in interferes)
            {
                Log.info(this, nameof(onUpdate), context.Source, context.Target);
                switch (context.Target.onAstralInterceptTry(context.Source))
                {
                    case AstralInterceptResult.Cancel_Through:
                    case AstralInterceptResult.Cancel_ActionEnd:
                        context.Source.onRejectInterference();
                        break;
                    case AstralInterceptResult.Establish:
                        context.Target.onAstralInterceptEstablished(context.Source);
                        context.Source.onAcceptInterference();
                        break;
                }
            }

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

