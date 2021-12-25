using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;
using until.develop;



namespace until.modules.gamefield
{
    public class StageSetupper : Singleton<StageSetupper>
    {
        #region Definition
        private enum Phase
        {
            Standby,
            Unload_Start,
            Unload_Wait,
            Load_Start,
            Load_Wait,
            Finish,
        }
        private class Context
        {
            public StageSetupOrder Order = null;
            public Action OnFinish = null;
        }
        #endregion

        #region Fields.
        private Context _CurrentContext = null;
        private Context _RequestedContext = null;
        private Phase _CurrentPhase = Phase.Standby;
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
        }
        #endregion

        #region Methods
        #region Behavior
        public void onStart()
        {
        }

        public void onUpdate()
        {
            switch (_CurrentPhase)
            {
                case Phase.Standby:
                    onUpdateStandby();
                    break;
                case Phase.Unload_Start:
                    onUpdateUnloadStart();
                    break;
                case Phase.Unload_Wait:
                    onUpdateUnloadWait();
                    break;
                case Phase.Load_Start:
                    onUpdateLoadStart();
                    break;
                case Phase.Load_Wait:
                    onUpdateLoadWait();
                    break;
                case Phase.Finish:
                    onUpdateFinish();
                    break;
            }
        }

        public void onDestroy()
        {
        }
        #endregion

        #region Processing.
        private void transit(Phase next)
        {
            Log.info(this, $"transit {_CurrentPhase} > {next}");
            switch (next)
            {
                case Phase.Standby:
                    onTransitStandby();
                    break;
                case Phase.Unload_Start:
                    onTransitUnloadStart();
                    break;
                case Phase.Unload_Wait:
                    onTransitUnloadWait();
                    break;
                case Phase.Load_Start:
                    onTransitLoadStart();
                    break;
                case Phase.Load_Wait:
                    onTransitLoadWait();
                    break;
                case Phase.Finish:
                    onTransitFinish();
                    break;
            }
            _CurrentPhase = next;
        }

        #region Standby
        private void onTransitStandby()
        {
        }
        private void onUpdateStandby()
        {
            if (_RequestedContext != null)
            {
                _CurrentContext = _RequestedContext;
                _RequestedContext = null;
                transit(Phase.Unload_Start);
            }
        }
        #endregion

        #region Unload_Start
        private void onTransitUnloadStart()
        {
            Singleton.StageSceneManager.requestToUnloadAll();
        }
        private void onUpdateUnloadStart()
        {
            transit(Phase.Unload_Wait);
        }
        #endregion

        #region Unload_Wait
        private void onTransitUnloadWait()
        {
        }
        private void onUpdateUnloadWait()
        {
            if (Singleton.StageSceneManager.IsAllUnloaded)
            {
                transit(Phase.Load_Start);
            }
        }
        #endregion

        #region Load_Start
        private void onTransitLoadStart()
        {
            if (_CurrentContext.Order.StageOrder != null)
            {
                foreach (var stage in _CurrentContext.Order.StageOrder)
                {
                    Singleton.StageSceneManager.request(stage.Stage, stage.Target);
                }
                transit(Phase.Load_Wait);
            }
            else
            {
                transit(Phase.Finish);
            }
        }
        private void onUpdateLoadStart()
        {
            transit(Phase.Load_Wait);
        }
        #endregion

        #region Load_Wait
        private void onTransitLoadWait()
        {
        }
        private void onUpdateLoadWait()
        {
            if (Singleton.StageSceneManager.IsProcessing)
            {
                transit(Phase.Finish);
            }
        }
        #endregion

        #region Finish
        private void onTransitFinish()
        {
        }
        private void onUpdateFinish()
        {
            if (_CurrentContext.OnFinish != null)
            {
                _CurrentContext.OnFinish();
            }
            _CurrentContext = null;
            transit(Phase.Standby);
        }
        #endregion
        #endregion


        #region Request
        public bool request(StageSetupOrder order, Action on_finish)
        {
            if (_RequestedContext != null)
            {
                return false;
            }

            _RequestedContext = new Context();
            _RequestedContext.Order = order;
            _RequestedContext.OnFinish = on_finish;
            return true;
        }
        #endregion
        #endregion
    }
}

