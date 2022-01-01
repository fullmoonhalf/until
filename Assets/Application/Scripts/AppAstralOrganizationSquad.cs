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
    public class AppAstralOrganizationSquad : AstralOrganizationGroup
    {
        #region Fields
        private Substance[] _MemberList = null;
        public int Capacity { get; private set; } = 0;
        public int Population { get; private set; } = 0;
        #endregion


        #region Methods
        public AppAstralOrganizationSquad(int capacity)
        {
            _MemberList = new Substance[capacity];
            Capacity = capacity;
        }

        #region Management
        public bool regist(Substance substance)
        {
            for (int index = 0; index < Capacity; ++index)
            {
                if (_MemberList[index] == null)
                {
                    _MemberList[index] = substance;
                    ++Population;
                    return true;
                }
            }
            return false;
        }

        public void unregist(Substance substance)
        {
            for (int index = 0; index < Capacity; ++index)
            {
                if (_MemberList[index] == substance)
                {
                    _MemberList[index] = null;
                    --Population;
                    break;
                }
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
            return null;
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
        #endregion

    }
}
