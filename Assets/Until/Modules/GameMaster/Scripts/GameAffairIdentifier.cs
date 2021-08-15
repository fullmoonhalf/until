using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using until.system;


namespace until.modules.gamemaster
{
    public class GameAffairIdentifier : Identifier<GameAffairIdentifier>
    {
        #region Properties
        public string Expression { get; private set; } = "";
        public override int Hashcode => _Hashcode;
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

        public override bool equal(GameAffairIdentifier other)
        {
            return _Hashcode == other._Hashcode;
        }
        #endregion
    }
}
