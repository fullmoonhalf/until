using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.modules.astral;



namespace until.test
{
    public abstract class AppAstralActionNpcBase : AppAstralActionBase
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
        public override AppAstralActionBase getNextAstralAction(AppAstralSpriteBase sprite)
        {
            return RefSubstance.OriginCongitation;
        }

        public override AstralInterceptResult onAstralInterceptTry(AstralInterfereable interferer)
        {
            return RefSubstance.OriginCongitation.onAstralInterceptTry(interferer);
        }

        public override bool onAstralActionUpdate(AppAstralSpriteBase sprite, float delta_time)
        {
            var keep_alive = onAstralNpcActionUpdate(sprite, delta_time);
            if (RefSubstance.OriginCongitation.Trapped)
            {
                keep_alive = false;
            }
            return keep_alive;
        }
        #endregion

        #region AstralNpcAction
        public abstract bool onAstralNpcActionUpdate(AppAstralSpriteBase sprite, float delta_time);
        #endregion
        #endregion
    }
}
