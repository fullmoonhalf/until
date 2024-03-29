﻿using System;
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
        public override AppAstralActionBase getNextAstralAction(AppAstralSpriteBase sprite)
        {
            return new AppAstralActionPlayerControl(RefSubstance);
        }

        public override void onAstralActionStart(AppAstralSpriteBase sprite)
        {
        }

        public override bool onAstralActionUpdate(AppAstralSpriteBase sprite, float delta_time)
        {
            return false;
        }
        public override void onAstralActionEnd(AppAstralSpriteBase sprite)
        {
        }

        public override AstralInterceptResult onAstralInterceptTry(AstralInterfereable interferer)
        {
            return AstralInterceptResult.Cancel_Through;
        }

        public override void onAstralInterceptEstablished(AstralInterfereable interferer)
        {
        }
        #endregion
        #endregion
    }
}
