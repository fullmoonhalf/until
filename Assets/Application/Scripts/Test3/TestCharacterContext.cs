using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace until.test3
{
    public class TestCharacterContext : CharacterContext
    {
        #region Fields
        public TestCharacterActionSelector ActionSelector { get; private set; } = null;
        #endregion

        #region Methods
        public TestCharacterContext()
        {
            ActionSelector = new TestCharacterActionSelector(this);
        }
        #endregion
    }
}

