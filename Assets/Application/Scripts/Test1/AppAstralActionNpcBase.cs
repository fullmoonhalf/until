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
        public virtual AstralAction getNextAstralAction(AstralSpritable sprite)
        {
            return RefSubstance.OriginCongitation;
        }

        public virtual AstralInterceptResult onAstralInterceptTry(AstralInterfereable interferer)
        {
            return RefSubstance.OriginCongitation.onAstralInterceptTry(interferer);
        }

        public bool onAstralActionUpdate(AstralSpritable sprite, float delta_time)
        {
            var keep_alive = onAstralNpcActionUpdate(sprite, delta_time);
            if (RefSubstance.OriginCongitation.Trapped)
            {
                keep_alive = false;
            }
            return keep_alive;
        }

        public virtual void onAstralWarp(AstralSpritable sprite, Vector3 position)
        {
        }

        public abstract void onAstralActionStart(AstralSpritable sprite);
        public abstract void onAstralActionEnd(AstralSpritable sprite);
        public abstract void onAstralInterceptEstablished(AstralInterfereable interferer);
        #endregion

        #region AstralNpcAction
        public abstract bool onAstralNpcActionUpdate(AstralSpritable sprite, float delta_time);
        #endregion
        #endregion
    }
}
