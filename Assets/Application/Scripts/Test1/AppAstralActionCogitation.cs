using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using until.modules.astral;
using until.utils;


namespace until.test
{
    /// <summary>
    /// 行動思考起点
    /// </summary>
    public abstract class AppAstralActionCogitation : AstralAction
    {
        #region Fields
        public abstract bool Trapped { get; }
        protected AppAstralOrganizationSquad BelongGroup { get; private set; } = null;
        #endregion

        #region Methods
        #region bind
        public void bind(AppAstralOrganizationSquad group)
        {
            BelongGroup = group;
        }
        #endregion

        #region AstralAction
        public abstract void onAstralActionStart(AstralSpritable sprite);
        public abstract bool onAstralActionUpdate(AstralSpritable sprite, float delta_time);
        public abstract void onAstralActionEnd(AstralSpritable sprite);
        public abstract AstralAction getNextAstralAction(AstralSpritable sprite);
        public abstract AstralInterceptResult onAstralInterceptTry(AstralInterfereable interferer);
        public abstract void onAstralInterceptEstablished(AstralInterfereable interferer);
        public abstract void onAstralWarp(AstralSpritable sprite, Vector3 position);
        #endregion
        #endregion
    }
}
