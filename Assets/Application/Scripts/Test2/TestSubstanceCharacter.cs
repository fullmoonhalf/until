using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.system;
using until.modules.astral;
using until.modules.gamefield;


namespace until.test2
{
    [DefaultExecutionOrder(until.system.settings.UntilBehaviorOrder.GameField_Substance)]
    public abstract class AppSubstanceCharacter : Substance
    {
        #region Field
        private TestAstralCharacterElement _BindedElement = null;
        #endregion

        #region Methods
        #region AppSubstanceCharacter
        public void bind(TestAstralCharacterElement element)
        {
            _BindedElement = element;
        }

        public void unbind()
        {
            _BindedElement = null;
        }
        #endregion
        #endregion
    }
}
