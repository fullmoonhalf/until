using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.develop;


namespace until.modules.astral
{
    public class AstralElement : AstralInterceptedable
    {
        #region Fields.
        public AstralAction _CurrentAction { get; private set; } = null;
        private AstralAction _NextAction = null;
        #endregion

        #region Methods.
        public AstralElement(AstralAction start_action)
        {
            _NextAction = start_action;
        }

        public void onAstralUpdate(float delta_time)
        {
            // このあたり仮。
            if (_NextAction != null)
            {
                _CurrentAction = _NextAction;
                _NextAction = null;
                if (_CurrentAction != null)
                {
                    Log.info(this, $"{nameof(onAstralUpdate)} change action {_CurrentAction}");
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

        public void onWarp(Vector3 position)
        {
            if (_CurrentAction != null)
            {
                _CurrentAction.onAstralWarp(position);
            }
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
