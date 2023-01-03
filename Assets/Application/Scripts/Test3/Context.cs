using System.Collections.Generic;
using until.system;


namespace until.test3
{
    public enum ContextRequestArrivalResult
    {
        Accept,
        Hold,
        Deny,
    }

    public abstract class Context
    {
        #region Definition
        protected abstract void onUpdate();
        protected abstract ContextRequestArrivalResult onSyncRequestAcceptableCheck(ContextSyncRequest request);
        protected abstract void onSyncRequestEstablished(ContextSyncRequest request);
        protected abstract void onSyncRequestCanceled(ContextSyncRequest request);
        protected abstract void onSyncFinalized(ContextSyncRequest request);
        #endregion

        #region Properties
        protected Context Myself { get; private set; } = null;
        protected Context[] Targets => _CurrentGuestSyncRequest?.Targets ?? null;
        #endregion

        #region Fields
        private ContextSyncRequest _CurrentOwnerSyncRequest = null;
        private ContextSyncRequest _CurrentGuestSyncRequest = null;
        private bool _NeedToClearSyncRequest = false;
        #endregion

        #region Methods
        public void update()
        {
            if (_NeedToClearSyncRequest)
            {
                _CurrentOwnerSyncRequest = null;
                _CurrentGuestSyncRequest = null;
                _NeedToClearSyncRequest = false;
            }
            if (_CurrentGuestSyncRequest != null)
            {
                return;
            }
            onUpdate();
        }

        /// <summary>
        /// リクエストを通してよいかを判断する
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ContextRequestArrivalResult checkSyncRequestAcceptable(ContextSyncRequest request)
        {
            return onSyncRequestAcceptableCheck(request);
        }

        /// <summary>
        /// リクエストが成立した場合に呼び出す
        /// </summary>
        /// <param name="request"></param>
        /// <param name="owner"></param>
        public void notifySyncRequestEstablished(ContextSyncRequest request, bool owner)
        {
            if (owner)
            {
                _CurrentOwnerSyncRequest = request;
                _CurrentGuestSyncRequest = null;
            }
            else
            {
                _CurrentOwnerSyncRequest = null;
                _CurrentGuestSyncRequest = request;
            }
            _NeedToClearSyncRequest = false;

            onSyncRequestEstablished(request);
        }

        /// <summary>
        /// 成立前にリクエストがキャンセルされた場合に呼び出す
        /// </summary>
        /// <param name="request"></param>
        public void notifySyncRequestCanceled(ContextSyncRequest request)
        {
            onSyncRequestCanceled(request);
        }

        /// <summary>
        /// 同期終了時に呼び出す
        /// </summary>
        /// <param name="request"></param>
        public void notifySyncFinalized(ContextSyncRequest request)
        {
            _NeedToClearSyncRequest = true;
            onSyncFinalized(request);
        }

        /// <summary>
        /// 同期を終了させる場合に呼び出す
        /// </summary>
        protected void endSync()
        {
            if (_CurrentOwnerSyncRequest == null)
            {
                return;
            }

            notifySyncFinalized(_CurrentOwnerSyncRequest);
            foreach (var target in _CurrentOwnerSyncRequest.Targets)
            {
                target.notifySyncFinalized(_CurrentGuestSyncRequest);
            }
        }
        #endregion
    }
}
