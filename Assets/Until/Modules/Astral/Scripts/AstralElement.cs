using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.develop;


namespace until.modules.astral
{
    public class AstralElement : AstralInterceptedable
    {
        #region Fields.
        private AstralAction _CurrentAction = null;
        private AstralAction _NextAction = null;
        #endregion

        #region Methods.
        public AstralElement(AstralAction action)
        {
            _NextAction = action;
        }

        public void onAstralUpdate(float delta_time)
        {
            // Ç±ÇÃÇ†ÇΩÇËâºÅB
            if (_NextAction != null)
            {
                _CurrentAction = _NextAction;
                _NextAction = null;
                if (_CurrentAction != null)
                {
                    Log.info(this, $"{nameof(onAstralUpdate)} change action {_CurrentAction.GetType().Name}");
                    _CurrentAction.onAstralActionStart();
                    return;
                }
            }
            if (_CurrentAction == null)
            {
                return;
            }

            var keep_alive = _CurrentAction.onAstralActionUpdate(delta_time);
            if (keep_alive)
            {
                return;
            }

            _CurrentAction.onAstralActionEnd();
            _NextAction = _CurrentAction.getNextAstralAction();
            _CurrentAction = null;
        }

        #region AstralInterceptable
        public bool onAstralInterceptTry(AstralInterfereable interferer)
        {
            if (_CurrentAction != null)
            {
                return _CurrentAction.onAstralInterceptTry(interferer);
            }
            return false;
        }

        public void onAstralInterceptEstablished(AstralInterfereable interferer)
        {
            if (_CurrentAction != null)
            {
                _CurrentAction.onAstralInterceptEstablished(interferer);
                _CurrentAction = null;
            }
        }
        #endregion
        #endregion
    }
}
