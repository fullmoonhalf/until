using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.modules.astral;


namespace until.test
{
    public abstract class AppAstralCompanyActionBase : AppAstralActionBase
    {
        #region Fields
        public AppAstralOrganizationCompany RefCompany { get; private set; } = null;
        #endregion

        #region Methods
        public AppAstralCompanyActionBase(AppAstralOrganizationCompany company)
        {
            RefCompany = company;
        }

        #region AstralAction
        public override AppAstralActionBase getNextAstralAction(AppAstralSpriteBase sprite)
        {
            return RefCompany.getNextAstralAction(sprite);
        }

        public override AstralInterceptResult onAstralInterceptTry(AstralInterfereable interferer)
        {
            return RefCompany.onAstralInterceptTry(interferer);
        }
        #endregion

        #region Squad
        public abstract AppAstralActionBase getSquadAstralAction(AppAstralOrganizationSquad squad);
        #endregion
        #endregion
    }
}
