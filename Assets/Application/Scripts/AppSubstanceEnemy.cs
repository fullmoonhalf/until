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
        public override AppAstralActionCogitation OriginCongitation
        {
            get
            {
                if (_OriginCongitation == null)
                {
                    _OriginCongitation = new AppAstralActionNpcCogitation(this);
                }
                return _OriginCongitation;
            }
        }
        private AppAstralActionNpcCogitation _OriginCongitation;
        #endregion
    }
}

