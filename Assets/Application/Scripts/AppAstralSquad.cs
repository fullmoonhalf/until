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
    public class AppAstralSquad : AstralOrganizationGroup
    {
        #region Fields
        public Substance[] MemberList { get; private set; } = null;
        public int Capacity { get; private set; } = 0;
        public int Population => _MemberCollection?.Count ?? 0;
        private AppAstralSquadActionBase _CurrentAction = null;
        private List<Substance> _MemberCollection = null;
        #endregion

        #region Methods
        public AppAstralSquad(int capacity)
        {
            _MemberCollection = new List<Substance>(capacity);
            MemberList = _MemberCollection.ToArray();
            Capacity = capacity;
        }

        #region Management
        public bool regist(Substance substance)
        {
            if (_MemberCollection.Count >= Capacity)
            {
                return false;
            }

            _MemberCollection.Add(substance);
            MemberList = _MemberCollection.ToArray();

            return true;
        }

        public void unregist(Substance substance)
        {
            if (_MemberCollection.Remove(substance))
            {
                MemberList = _MemberCollection.ToArray();
            }
        }
        #endregion

        #region AstralAction
        public override void onAstralActionStart()
        {
        }

        public override bool onAstralActionUpdate(float delta_time)
        {
            return false;
        }

        public override void onAstralActionEnd()
        {
        }

        public override AstralAction getNextAstralAction()
        {
            _CurrentAction = new AppAstralSquadMove(this);
            return _CurrentAction;
        }

        public override bool onAstralInterceptTry(AstralInterfereable interferer)
        {
            return false;
        }

        public override void onAstralInterceptEstablished(AstralInterfereable interferer)
        {
        }

        public override void onAstralWarp(Vector3 position)
        {
        }
        #endregion

        #region AstralOrganizationGroup
        public AstralAction getMemberAstralAction(AppSubstanceCharacter substance)
        {
            if (_CurrentAction != null)
            {
                return _CurrentAction.getMemberAstralAction(substance);
            }
            return null;
        }
        #endregion
        #endregion

    }
}
