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
        public AppSubstanceCharacter[] MemberList { get; private set; } = null;
        public int Capacity { get; private set; } = 0;
        public int Population => _MemberCollection?.Count ?? 0;
        private AppAstralSquadActionBase _CurrentAction = null;
        private List<AppSubstanceCharacter> _MemberCollection = null;
        private int[] _Route = null;
        private int _RouteIndex = -1;
        #endregion

        #region Methods
        public AppAstralOrganizationSquad(int capacity)
        {
            _MemberCollection = new List<AppSubstanceCharacter>(capacity);
            MemberList = _MemberCollection.ToArray();
            Capacity = capacity;
        }

        #region Information
        /// <summary>
        /// 平均位置を求める
        /// </summary>
        /// <returns>平均位置</returns>
        public Vector3 getCenterPosition()
        {
            var center = Vector3.zero;
            foreach (var member in MemberList)
            {
                center += member.Position;
            }
            center = center / MemberList.Length;
            return center;
        }

        /// <summary>
        /// ポジションゼロを取得する。
        /// </summary>
        /// <returns>平均位置に一番近いメンバーの座標</returns>
        public Vector3 getPositionZero()
        {
            var center = getCenterPosition();
            var position_zero = center;
            var min_distance_sq = float.MaxValue;
            foreach (var member in MemberList)
            {
                var gap = center - member.Position;
                if (min_distance_sq > gap.sqrMagnitude)
                {
                    min_distance_sq = gap.sqrMagnitude;
                    position_zero = member.Position;
                }
            }
            return position_zero;
        }
        #endregion

        #region Management
        public bool regist(Substance substance)
        {
            if (_MemberCollection.Count >= Capacity)
            {
                return false;
            }
            if (substance is AppSubstanceCharacter character)
            {
                _MemberCollection.Add(character);
                MemberList = _MemberCollection.ToArray();
                return true;
            }
            return false;
        }

        public void unregist(Substance substance)
        {
            if (substance is AppSubstanceCharacter character)
            {
                if (_MemberCollection.Remove(character))
                {
                    MemberList = _MemberCollection.ToArray();
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
            _CurrentAction = new AppAstralSquadMove(this, _Route, _RouteIndex);
            if (_Route != null)
            {
                _RouteIndex = _Route.Length - 1;
            }
            return _CurrentAction;
        }

        public override AstralInterceptResult onAstralInterceptTry(AstralInterfereable interferer)
        {
            switch (interferer)
            {
                case AppAstralInterfererOnCombatSectorUpdate onCombatSectorUpdate:
                    {
                        _Route = onCombatSectorUpdate.Route;
                        _RouteIndex = _Route.Length > 1 ? 1 : 0;
                        foreach (var member in MemberList)
                        {
                            member.interfere(interferer);
                        }
                    }
                    return AstralInterceptResult.Cancel_ActionEnd;
            }
            return AstralInterceptResult.Cancel_Through;
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
