using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace until.test3
{
    public abstract class CharacterContext : Context
    {
        #region Definition
        #endregion

        #region Properties
        public Locator Locator { get; private set; } = null;
        #endregion

        #region Fields
        #endregion

        #region Methods
        public void bind(Locator locator)
        {
            Locator = locator;
        }
        #endregion

        #region Develop
        #endregion

    }
}

