using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.modules.astral;


namespace until.test
{
    [DefaultExecutionOrder(until.system.settings.UntilBehaviorOrder.GameField_Substance)]
    public class AppSubstancePlayer : AppSubstanceCharacter
    {
        #region Fields.
        #endregion

        #region Methods
        #region AppSubstanceCharacter
        protected override AstralAction getCogitationOrigin()
        {
            return new AppAstralActionPlayerControl(this);
        }
        #endregion
        #endregion
    }
}

