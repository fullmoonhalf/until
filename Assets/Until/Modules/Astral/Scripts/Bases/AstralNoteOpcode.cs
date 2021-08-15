using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;


namespace until.modules.astral
{
    public class AstralNoteOpcode : Identifier<AstralNoteOpcode>
    {
        #region Properties
        public override int Hashcode => _HashCode;
        /// <summary>ニモニック</summary>
        public string Mnemonic { get; private set; } = "";
        #endregion

        #region Fields
        /// <summary>ハッシュ値</summary>
        private int _HashCode = 0;
        #endregion

        #region Methods
        /// <summary>
        /// コンストラクタ
        /// </summary>
        [Obsolete("Do not use default constructor.", true)]
        public AstralNoteOpcode()
        {

        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mnemonic">ニモニック</param>
        public AstralNoteOpcode(string mnemonic)
        {
            Mnemonic = mnemonic;
            _HashCode = mnemonic.GetHashCode();
        }

        public override bool equal(AstralNoteOpcode other)
        {
            return Mnemonic == other.Mnemonic;
        }
        #endregion
    }
}

