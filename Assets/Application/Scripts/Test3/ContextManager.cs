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
        private List<ContextSyncRequest> _SyncRequestCollection = null;
        #endregion


        #region Methods.
        #region ContextManager
        public void update()
        {
            var count = _ContextCollection.Count;
            for (var index = 0; index < count; ++index)
            {
                execUpdate(_ContextCollection[index]);
            }
        }

        private void execUpdate(Context context)
        {
            context.update();
        }

        public void mediateSyncRequest()
        {
            _SyncRequestCollection.Sort((a, b) => a.Priority - b.Priority);
            _SyncRequestCollection.RemoveAll(execSyncRequest);
        }

        /// <summary>
        /// 同期リクエストの成立確認
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private bool execSyncRequest(ContextSyncRequest request)
        {
            var all_accepted = true;
            var all_denied = true;
            foreach (var target in request.Targets)
            {
                var result = target.checkSyncRequestAcceptable(request);
                switch (result)
                {
                    case ContextRequestArrivalResult.Accept:
                        all_denied = false;
                        break;
                    case ContextRequestArrivalResult.Hold:
                        all_accepted = false;
                        all_denied = false;
                        break;
                    case ContextRequestArrivalResult.Deny:
                        all_accepted = false;
                        break;
                }
            }

            if (all_accepted)
            {
                request.Requester.notifySyncRequestEstablished(request, true);
                foreach (var target in request.Targets)
                {
                    target.notifySyncRequestEstablished(request, false);
                }
                return true;
            }

            if (all_denied)
            {
                request.Requester.notifySyncRequestCanceled(request);
                foreach (var target in request.Targets)
                {
                    target.notifySyncRequestCanceled(request);
                }
                return true;
            }

            return false;
        }
        #endregion


        #region Singleton
        public override void onSingletonAwake()
        {
            _ContextCollection = new List<Context>();
            _SyncRequestCollection = new List<ContextSyncRequest>();
        }

        public override void onSingletonStart()
        {
        }

        public override void onSingletonDestroy()
        {
            _SyncRequestCollection = null;
            _ContextCollection = null;
        }
        #endregion
        #endregion
    }
}
