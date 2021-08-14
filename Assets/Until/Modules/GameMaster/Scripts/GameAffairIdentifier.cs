using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace until.modules.gamemaster
{
    public class GameAffairIdentifier : IEquatable<GameAffairIdentifier>
    {
        #region Properties
        public string Expression { get; private set; } = "";
        #endregion

        #region Fields.
        private int _Hashcode = 0;
        #endregion

        #region Methods
        public GameAffairIdentifier(string mnemonic)
        {
            Expression = mnemonic;
            _Hashcode = Expression.GetHashCode();
        }

        #region 等価性判断
        public override bool Equals(object obj)
        {
            if (obj is GameAffairIdentifier id)
            {
                return Equals(id);
            }
            return false;
        }

        public bool Equals(GameAffairIdentifier other)
        {
            if (other == null)
            {
                return false;
            }
            if (_Hashcode != other._Hashcode)
            {
                return false;
            }
            return _Hashcode == other._Hashcode;
        }

        public override int GetHashCode()
        {
            return _Hashcode;
        }

        public static bool operator ==(GameAffairIdentifier lhs, GameAffairIdentifier rhs)
        {
            return lhs != null && lhs.Equals(rhs);
        }
        public static bool operator !=(GameAffairIdentifier lhs, GameAffairIdentifier rhs)
        {
            return !(lhs == rhs);
        }
        #endregion
        #endregion
    }
}
