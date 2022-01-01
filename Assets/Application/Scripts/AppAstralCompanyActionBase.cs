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
        public AstralAction getNextAstralAction()
        {
            return RefCompany.getNextAstralAction();
        }

        public void onAstralWarp(Vector3 position)
        {
        }

        public abstract void onAstralActionStart();
        public abstract bool onAstralActionUpdate(float delta_time);
        public abstract void onAstralActionEnd();
        public abstract bool onAstralInterceptTry(AstralInterfereable interferer);
        public abstract void onAstralInterceptEstablished(AstralInterfereable interferer);
        #endregion

        #region Squad
        public abstract AstralAction getSquadAstralAction(AppAstralOrganizationSquad squad);
        #endregion
        #endregion
    }
}
