using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.modules.astral;


namespace until.test
{
    [DefaultExecutionOrder(system.defines.ExecutionOrder.Undefined)]
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

