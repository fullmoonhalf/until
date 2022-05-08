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
    public class AppAstralOrganizationCompany : AppAstralElement
    {
        #region Fields
        public AppAstralOrganizationSquad[] SquadList { get; private set; }
        private List<AppAstralOrganizationSquad> _SquadList = new List<AppAstralOrganizationSquad>();
        #endregion

        #region Methods
        public AppAstralOrganizationCompany()
            : base(null, null, null)
        {
        }


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
        public AppAstralActionBase getNextAstralAction(AppAstralSpriteBase sprite)
        {
            return new AppAstralCompanyCombat(this);
        }
        #endregion

        #region AstralOrganizationGroup
        public AppAstralActionBase getMemberAstralAction(AppSubstanceCharacter substance)
        {
            return null;
        }
        #endregion
        #endregion
    }
}
