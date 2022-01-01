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
    public class AppAstralActionPlayerCogitation : AppAstralActionCogitation
    {
        #region Fields
        public override bool Trapped => false;
        protected AppSubstancePlayer RefSubstance { get; private set; } = null;
        #endregion

        #region Methods
        public AppAstralActionPlayerCogitation(AppSubstancePlayer substance)
        {
            RefSubstance = substance;
        }

        #region AstralAction
        public override AstralAction getNextAstralAction()
        {
            return new AppAstralActionPlayerControl(RefSubstance);
        }

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
