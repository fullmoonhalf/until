using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.modules.astral;


namespace until.test
{
    [DefaultExecutionOrder(until.system.settings.UntilBehaviorOrder.GameField_Substance)]
    public class AppSubstanceEnemy : AppSubstanceCharacter
    {
        #region Fields.
        private AppAstralActionNpcCogitation _OriginalCognition = null;
        #endregion

        #region Methods
        #region AppSubstanceCharacter
        protected override AstralAction getCogitationOrigin()
        {
            _OriginalCognition = new AppAstralActionNpcCogitation(this);
            return _OriginalCognition;
        }
        #endregion
        #endregion
    }
}

