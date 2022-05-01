using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.develop;


namespace until.modules.astral
{
    public class AstralElement : AstralInterceptedable
    {
        #region Fields.
        public AstralAction CurrentAction { get; private set; } = null;
        private AstralAction _NextAction = null;
        private AstralInterceptedable _InterceptReceiver = null;
        private AstralSpritable _RefSprite = null;
        #endregion

        #region Methods.
        public AstralElement(AstralAction start_action, AstralInterceptedable receiver)
        {
            _NextAction = start_action;
            _InterceptReceiver = receiver;
            _RefSprite = null;
        }

        public AstralElement(AstralAction start_action, AstralSpritable sprite)
        {
            _NextAction = start_action;
            _InterceptReceiver = sprite;
            _RefSprite = sprite;
        }

        public void onAstralUpdate(float delta_time)
        {
            // Ç±ÇÃÇ†ÇΩÇËâºÅB
            if (_NextAction != null)
            {
                CurrentAction = _NextAction;
                _NextAction = null;
                if (CurrentAction != null)
                {
                    CurrentAction.onAstralActionStart(_RefSprite);
                    return;
                }
            }
            if (CurrentAction == null)
            {
                return;
            }

            var keep_alive = CurrentAction.onAstralActionUpdate(_RefSprite, delta_time);
            if (keep_alive)
            {
                return;
            }

            execActionEnd();
        }

        private void execActionEnd()
        {
            if (CurrentAction != null)
            {
                CurrentAction.onAstralActionEnd(_RefSprite);
                _NextAction = CurrentAction.getNextAstralAction(_RefSprite);
                CurrentAction = null;
            }
        }

        #region AstralInterceptable
        public AstralInterceptResult onAstralInterceptTry(AstralInterfereable interferer)
        {
            if (_InterceptReceiver != null)
            {
                var result = _InterceptReceiver.onAstralInterceptTry(interferer);
                if (result == AstralInterceptResult.Cancel_ActionEnd)
                {
                    execActionEnd();
                }
                return result;
            }
            return AstralInterceptResult.Cancel_Through;
        }

        public void onAstralInterceptEstablished(AstralInterfereable interferer)
        {
            if (_InterceptReceiver != null)
            {
                _InterceptReceiver.onAstralInterceptEstablished(interferer);
                execActionEnd();
            }
        }
        #endregion
        #endregion
    }
}
