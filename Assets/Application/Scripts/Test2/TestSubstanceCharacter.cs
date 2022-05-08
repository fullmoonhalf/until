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
    public class TestSubstanceCharacter : Substance
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

        #region Substance
        public override Vector3 Position
        {
            get => _Position;
            set => _Position = value;
        }
        private Vector3 _Position = Vector3.zero;

        protected override void onWarp(Vector3 position)
        {
            _Position = position;
        }
        #endregion
        #endregion
    }
}
