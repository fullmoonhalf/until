using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace until.modules.gamemaster
{
    public class GameParameter
    {
        #region Properties
        public GameParameterIdentifier Identifier { get; private set; } = null;
        public GameRecord Value { get; private set; } = new GameRecord();
        #endregion

        #region Fields
        private Dictionary<GameAffairIdentifier, GameRecord> AffairRecords = new Dictionary<GameAffairIdentifier, GameRecord>();
        #endregion

        #region Methods
        /// <summary>
        /// コンストラクタ
        /// </summary>
        [Obsolete("Do not use default constructor.", true)]
        public GameParameter()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="identifier"></param>
        public GameParameter(GameParameterIdentifier identifier)
        {
            Identifier = identifier;
        }

        /// <summary>
        /// 値の設定
        /// </summary>
        /// <param name="affair"></param>
        /// <param name="value"></param>
        public void set(GameAffairIdentifier affair, int value)
        {
            Value.set(value);

            if (AffairRecords.TryGetValue(affair, out var record))
            {
                record.set(value);
            }
        }

        /// <summary>
        /// 値の取得
        /// </summary>
        /// <param name="affair"></param>
        /// <returns></returns>
        public GameRecord get(GameAffairIdentifier affair)
        {
            if (AffairRecords.TryGetValue(affair, out var record))
            {
                return record;
            }
            return null;
        }
        #endregion
    }
}
