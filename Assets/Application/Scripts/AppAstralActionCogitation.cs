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
        public void bind(AppAstralOrganizationSquad group)
        {
            BelongGroup = group;
        }

        #region AstralAction
        public abstract void onAstralActionStart();
        public abstract bool onAstralActionUpdate(float delta_time);
        public abstract void onAstralActionEnd();
        public abstract AstralAction getNextAstralAction();
        public abstract AstralInterceptResult onAstralInterceptTry(AstralInterfereable interferer);
        public abstract void onAstralInterceptEstablished(AstralInterfereable interferer);
        public abstract void onAstralWarp(Vector3 position);
        #endregion
        #endregion
    }
}
