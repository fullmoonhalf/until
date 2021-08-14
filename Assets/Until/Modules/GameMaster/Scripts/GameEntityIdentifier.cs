using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using until.system;


namespace until.modules.gamemaster
{
    public class GameEntityIdentifier : Identifier<GameEntityIdentifier>
    {
        #region Properties
        public string Expression { get; private set; } = "";
        public override int Hashcode => _Hashcode;
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

        public override bool equal(GameEntityIdentifier other)
        {
            return Expression == other.Expression;
        }
        #endregion
    }
}
