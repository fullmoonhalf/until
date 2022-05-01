using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.modules.astral;


namespace until.test
{
    public abstract class AppAstralCompanyActionBase : AstralAction
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
        public AstralAction getNextAstralAction(AstralSpritable sprite)
        {
            return RefCompany.getNextAstralAction(sprite);
        }

        public void onAstralWarp(AstralSpritable sprite, Vector3 position)
        {
        }

        public virtual AstralInterceptResult onAstralInterceptTry(AstralInterfereable interferer)
        {
            return RefCompany.onAstralInterceptTry(interferer);
        }

        public abstract void onAstralActionStart(AstralSpritable sprite);
        public abstract bool onAstralActionUpdate(AstralSpritable sprite, float delta_time);
        public abstract void onAstralActionEnd(AstralSpritable sprite);
        public abstract void onAstralInterceptEstablished(AstralInterfereable interferer);
        #endregion

        #region Squad
        public abstract AstralAction getSquadAstralAction(AppAstralOrganizationSquad squad);
        #endregion
        #endregion
    }
}
