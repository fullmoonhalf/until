using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.modules.astral;
using until.modules.gamefield;


namespace until.test
{
    public class AppAstralOrganizationCompany : AstralOrganizationGroup
    {
        #region Fields
        public AppAstralOrganizationSquad[] SquadList { get; private set; }
        private List<AppAstralOrganizationSquad> _SquadList = new List<AppAstralOrganizationSquad>();
        #endregion

        #region Methods
        #region Management
        public void regist(AppAstralOrganizationSquad squad)
        {
            _SquadList.Add(squad);
            SquadList = _SquadList.ToArray();
        }
        public void unregist(AppAstralOrganizationSquad squad)
        {
            _SquadList.Remove(squad);
            SquadList = _SquadList.ToArray();
        }
        #endregion

        #region AstralAction
        public override void onAstralActionStart(AstralSpritable sprite)
        {
        }

        public override bool onAstralActionUpdate(AstralSpritable sprite, float delta_time)
        {
            return false;
        }

        public override void onAstralActionEnd(AstralSpritable sprite)
        {
        }

        public override AstralAction getNextAstralAction(AstralSpritable sprite)
        {
            return new AppAstralCompanyCombat(this);
        }

        public override AstralInterceptResult onAstralInterceptTry(AstralInterfereable interferer)
        {
            return AstralInterceptResult.Cancel_Through;
        }

        public override void onAstralInterceptEstablished(AstralInterfereable interferer)
        {
        }

        public override void onAstralWarp(AstralSpritable sprite, Vector3 position)
        {
        }
        #endregion

        #region AstralOrganizationGroup
        public AstralAction getMemberAstralAction(AppSubstanceCharacter substance)
        {
            return null;
        }
        #endregion
        #endregion
    }
}
