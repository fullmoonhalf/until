using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.modules.astral;



namespace until.test
{
    public abstract class AppAstralActionNpcBase : AstralAction
    {
        #region Fields
        protected AppSubstanceCharacter RefSubstance { get; private set; } = null;
        #endregion

        #region Methods
        public AppAstralActionNpcBase(AppSubstanceCharacter substance)
        {
            RefSubstance = substance;
        }

        #region AstralAction
        public virtual AstralAction getNextAstralAction()
        {
            return RefSubstance.OriginCongitation;
        }

        public virtual AstralInterceptResult onAstralInterceptTry(AstralInterfereable interferer)
        {
            return RefSubstance.OriginCongitation.onAstralInterceptTry(interferer);
        }

        public bool onAstralActionUpdate(float delta_time)
        {
            var keep_alive = onAstralNpcActionUpdate(delta_time);
            if (RefSubstance.OriginCongitation.Trapped)
            {
                keep_alive = false;
            }
            return keep_alive;
        }

        public virtual void onAstralWarp(Vector3 position)
        {
        }

        public abstract void onAstralActionStart();
        public abstract void onAstralActionEnd();
        public abstract void onAstralInterceptEstablished(AstralInterfereable interferer);
        #endregion

        #region AstralNpcAction
        public abstract bool onAstralNpcActionUpdate(float delta_time);
        #endregion
        #endregion
    }
}
