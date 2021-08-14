using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.astral
{
    public class AstralNoteOpcode : IEquatable<AstralNoteOpcode>
    {
        #region Properties
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

        #region 等価性判断
        public override int GetHashCode()
        {
            return _HashCode;
        }


        public override bool Equals(object obj)
        {
            if (obj is AstralNoteOpcode code)
            {
                return Equals(code);
            }
            return false;
        }

        public bool Equals(AstralNoteOpcode other)
        {
            if (_HashCode != other._HashCode)
            {
                return false;
            }
            return Mnemonic == other.Mnemonic;
        }

        public static bool operator ==(AstralNoteOpcode lhs, AstralNoteOpcode rhs)
        {
            if (lhs != null && rhs != null)
            {
                return lhs.Equals(rhs);
            }
            return false;
        }

        public static bool operator !=(AstralNoteOpcode lhs, AstralNoteOpcode rhs)
        {
            return !(lhs == rhs);
        }
        #endregion
        #endregion
    }
}

