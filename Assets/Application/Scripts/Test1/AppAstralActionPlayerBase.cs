using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.modules.astral;



namespace until.test
{
    public abstract class AppAstralActionPlayerBase : AppAstralActionBase
    {
        #region Fields
        protected AppSubstancePlayer RefPlayer { get; private set; } = null;
        #endregion

        #region Methods
        public AppAstralActionPlayerBase(AppSubstancePlayer player)
        {
            RefPlayer = player;
        }

        #region AstralAction
        public override AppAstralActionBase getNextAstralAction(AppAstralSpriteBase sprite)
        {
            return new AppAstralActionPlayerControl(RefPlayer);
            }
        #endregion
        #endregion
    }
}
