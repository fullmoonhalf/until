using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.modules.astral;


namespace until.test
{
    [DefaultExecutionOrder(system.defines.ExecutionOrder.Undefined)]
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

