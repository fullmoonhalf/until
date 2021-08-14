using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace until.modules.gamemaster
{
    public class GameEntityIdentifier : IEquatable<GameEntityIdentifier>
    {
        #region Properties
        public string Expression { get; private set; } = "";
        #endregion

        #region Fields.
        private int _Hashcode = 0;
        #endregion

        #region Methods
        public GameEntityIdentifier(object value)
        {
            Expression = $"{value.GetType().Name}.{value}";
            _Hashcode = Expression.GetHashCode();
        }

        #region 等価性判断
        public override bool Equals(object obj)
        {
            if (obj is GameEntityIdentifier id)
            {
                return Equals(id);
            }
            return false;
        }

        public bool Equals(GameEntityIdentifier other)
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

        public static bool operator ==(GameEntityIdentifier lhs, GameEntityIdentifier rhs)
        {
            return lhs != null && lhs.Equals(rhs);
        }
        public static bool operator !=(GameEntityIdentifier lhs, GameEntityIdentifier rhs)
        {
            return !(lhs == rhs);
        }
        #endregion
        #endregion
    }
}
