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
        public virtual string Expression { get; } = "";
        public override int Hashcode => _Hashcode;
        #endregion

        #region Fields.
        private int _Hashcode = 0;
        #endregion

        #region Methods
        protected GameEntityIdentifier()
        {
        }

        public GameEntityIdentifier(object value)
        {
            Expression = $"{value.GetType().FullName}.{value}";
            _Hashcode = Expression.GetHashCode();
        }

        public override bool equal(GameEntityIdentifier other)
        {
            return Expression == other.Expression;
        }
        #endregion
    }
}
