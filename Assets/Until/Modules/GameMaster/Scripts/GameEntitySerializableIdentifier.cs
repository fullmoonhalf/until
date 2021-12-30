using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.system;


namespace until.modules.gamemaster
{
    [Serializable]
    public class GameEntitySerializableIdentifier : GameEntityIdentifier
    {
        #region Inspector
        [SerializeField]
        private bool _Serialized = true;
        [SerializeField]
        private string _Expression = "";
        #endregion

        #region Properties
        public override string Expression
        {
            get
            {
                if (_InvalidCache)
                {
                    updateActualExpression();
                }
                return _ActualExpression;
            }
        }
        public override int Hashcode
        {
            get
            {
                if (_InvalidCache)
                {
                    updateActualExpression();
                }
                return _ActualHashcode;
            }
        }
        public bool Serialized => _Serialized;
        #endregion

        #region Fields.
        private bool _InvalidCache = true;
        private int _ActualHashcode = 0;
        private string _ActualExpression = "";
        #endregion

        #region Methods
        public GameEntitySerializableIdentifier()
        {
        }

        public GameEntitySerializableIdentifier(string identifier)
        {
            _Expression = identifier;
            _Serialized = false;
            updateActualExpression();
        }

        private void updateActualExpression()
        {
            _ActualExpression = $"Astral.{_Expression}";
            _ActualHashcode = _ActualExpression.GetHashCode();
            _InvalidCache = false;
        }
        #endregion
    }
}
