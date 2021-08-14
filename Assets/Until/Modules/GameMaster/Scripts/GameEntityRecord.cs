using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace until.modules.gamemaster
{
    public class GameEntityRecord
    {
        #region Fields.
        public GameEntityIdentifier Identifier { get; private set; }
        public GameRecord Record { get; private set; } = new GameRecord();
        public Dictionary<GameEntityIdentifier, GameEntityRecord> Collection { get; private set; } = new Dictionary<GameEntityIdentifier, GameEntityRecord>();
        #endregion

        #region Methods
        public GameEntityRecord()
        {
        }


        /// <summary>
        /// 値の設定
        /// </summary>
        /// <param name="value"></param>
        public void set(int value)
        {
            Record.set(value);
        }

        /// <summary>
        /// 値の設定
        /// </summary>
        /// <param name="value"></param>
        /// <param name="target"></param>
        public void set(int value, GameEntityIdentifier target)
        {
            Record.set(value);

            if (Collection.TryGetValue(target, out var record))
            {
                record.set(value);
            }
            else
            {
                record = new GameEntityRecord();
                record.set(value);
                Collection.Add(target, record);
            }
        }
        #endregion
    }
}
