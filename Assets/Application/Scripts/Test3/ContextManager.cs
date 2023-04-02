using System.Collections.Generic;
using until.system;
using until.develop;

namespace until.test3
{
    public class ContextManager : Singleton<ContextManager>
#if TEST
        , DevelopIndicatorElement
#endif
    {
        #region Definitions
        #endregion

        #region Fields.
        private List<Context> _ContextCollection = null;
        private List<Action> _ActionCollection = null;
        private List<Action> _AddActionCollection = null;
        #endregion

        #region Methods.
        #region ContextManager
        public void update(in DeltaSituation ds)
        {
            lock (_AddActionCollection)
            {
                _ActionCollection.AddRange(_AddActionCollection);
                _AddActionCollection.Clear();
            }

            var exec_action_list = _ActionCollection.ToArray();
            _ActionCollection.Clear();
            for (var index = 0; index < exec_action_list.Length; ++index)
            {
                var action = exec_action_list[index];
                var next_action = action.onUpdate(ds);
                if (next_action != null)
                {
                    _ActionCollection.Add(next_action);
                }
            }
        }

        /// <summary>
        /// ìoò^
        /// </summary>
        /// <param name="context"></param>
        public void regist(Context context)
        {
            _ContextCollection.Add(context);
        }

        /// <summary>
        /// ìoò^âèú
        /// </summary>
        /// <param name="context"></param>
        public void unregist(Context context)
        {
            _ContextCollection.Remove(context);
        }

        /// <summary>
        /// ìoò^
        /// </summary>
        /// <param name="action"></param>
        public void regist(Action action)
        {
            lock (_AddActionCollection)
            {
                _AddActionCollection.Add(action);
            }
        }
        #endregion

        #region Singleton
        public override void onSingletonAwake()
        {
            _ContextCollection = new List<Context>();
            _ActionCollection = new List<Action>();
            _AddActionCollection = new List<Action>();
        }

        public override void onSingletonStart()
        {
        }

        public override void onSingletonDestroy()
        {
            _ContextCollection = null;
        }
        #endregion
        #endregion

        #region Develop
#if TEST
        string DevelopIndicatorElement.DevelopIndicatorText => _DevelopIndicatorText;
        int DevelopIndicatorElement.DevelopIndicatorWidth => 500;
        int DevelopIndicatorElement.DevelopIndicatorHeight => 200;
        private string _DevelopIndicatorText = "";

        void DevelopIndicatorElement.onIndicatorUpdate()
        {
            var length = _ActionCollection.Count;
            _DevelopIndicatorText = $"Action #{length}";
            for (var index = 0; index < length; ++index)
            {
                var action = _ActionCollection[index];
                _DevelopIndicatorText += "\n" + action.DebugStatus;
            }
        }
#endif
        #endregion
    }
}
