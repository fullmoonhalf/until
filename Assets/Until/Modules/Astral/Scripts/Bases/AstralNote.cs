using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.astral
{
    public abstract class AstralNote
    {
        #region Defines
        public abstract AstralNoteOpcode Opcode { get; }
        public abstract AstralNoteContext createContext();
        #endregion

        #region Methods.
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AstralNote()
        {
        }
        #endregion
    }
}

