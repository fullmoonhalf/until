using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.modules.astral;


namespace until.test
{
    public abstract class AppAstralSquadActionBase : AppAstralActionBase
    {
        #region Fields
        public AppAstralOrganizationSquad RefSquad { get; private set; } = null;
        #endregion

        #region Methods
        public AppAstralSquadActionBase(AppAstralOrganizationSquad squad)
        {
            RefSquad = squad;
        }

        #region AstralAction
        public override AppAstralActionBase getNextAstralAction(AppAstralSpriteBase sprite)
        {
            return RefSquad.getNextAstralAction(sprite);
        }

        public override AstralInterceptResult onAstralInterceptTry(AstralInterfereable interferer)
        {
            return RefSquad.onAstralInterceptTry(interferer);
        }
        #endregion

        #region Squad
        public abstract AppAstralActionBase getMemberAstralAction(AppSubstanceCharacter substance);
        #endregion
        #endregion
    }
}
