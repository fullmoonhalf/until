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
        #region AppSubstanceCharacter
        protected override AstralAction getCogitationOrigin()
        {
            return new AppAstralActionNpcCogitation(this);
        }
        #endregion
        #endregion
    }
}

