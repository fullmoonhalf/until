using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.develop;


namespace until.modules.astral
{
    public interface AstralElementable : AstralInterceptedable
    {
        public void onAstralUpdate(float delta_time);
    }

    public class AstralElement<TypeAstralAction, TypeAstralSprite> : AstralElementable
        where TypeAstralAction : AstralActionable<TypeAstralAction, TypeAstralSprite>
        where TypeAstralSprite : AstralSpritable<TypeAstralSprite>
    {
        #region Fields.
        public TypeAstralAction CurrentAction { get; private set; } = null;
        private TypeAstralAction _NextAction = null;
        private AstralInterceptedable _InterceptReceiver = null;
        private TypeAstralSprite _RefSprite = null;
        #endregion

        #region Methods.
        public AstralElement(TypeAstralAction start_action, AstralInterceptedable receiver, TypeAstralSprite sprite)
        {
            _NextAction = start_action;
            _InterceptReceiver = receiver;
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
