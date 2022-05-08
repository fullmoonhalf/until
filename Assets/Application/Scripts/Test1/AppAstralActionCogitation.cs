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
    public abstract class AppAstralActionCogitation : AppAstralActionBase
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
        #endregion
    }
}
