using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.modules.astral;
using until.utils;


namespace until.test
{
    public class AppAstralActionNpcCogitation : AstralAction
    {
        #region Fields
        protected AppSubstanceCharacter RefSubstance { get; private set; } = null;
        #endregion

        #region Methods
        public AppAstralActionNpcCogitation(AppSubstanceCharacter substance)
        {
            RefSubstance = substance;
        }

        #region AstralAction
        public AstralAction getNextAstralAction()
        {
            var x = math.getRandomRange(-5.0f, 5.0f);
            var z = math.getRandomRange(-5.0f, 5.0f);
            var pos = new Vector3(x, 0.0f, z);
            var action = new AppAstralActionNpcMove(RefSubstance, this, pos);
            return action;
        }

        public void onAstralActionStart()
        {
        }
        public bool onAstralActionUpdate(float delta_time)
        {
            return false;
        }
        public void onAstralActionEnd()
        {
        }
        #endregion
        #endregion
    }
}
