using System.Collections.Generic;
using until.system;


namespace until.test3
{
    public class ContextManager : Singleton<ContextManager>
    {
        #region Definitions
        #endregion

        #region Fields.
        private List<Context> _ContextCollection = null;
        #endregion


        #region Methods.
        #region ContextManager
        public void update(in DeltaSituation ds)
        {
            var count = _ContextCollection.Count;
            for (var index = 0; index < count; ++index)
            {
                execUpdate(_ContextCollection[index], ds);
            }
        }

        private void execUpdate(Context context, in DeltaSituation ds)
        {
            context.update(ds);
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
        #endregion

        #region Singleton
        public override void onSingletonAwake()
        {
            _ContextCollection = new List<Context>();
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
    }
}
