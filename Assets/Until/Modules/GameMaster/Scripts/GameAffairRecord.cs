using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace until.modules.gamemaster
{
    public class GameAffairRecord
    {
        #region Fields.
        public GameAffairIdentifier Identifier { get; private set; }
        public GameRecord Record { get; private set; } = new GameRecord();
        public Dictionary<GameEntityIdentifier, GameEntityRecord> Collection { get; private set; } = new Dictionary<GameEntityIdentifier, GameEntityRecord>();
        #endregion

        #region Methods
        public GameAffairRecord()
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
        /// <param name="source"></param>
        public void set(int value, GameEntityIdentifier source)
        {
            Record.set(value);

            if (Collection.TryGetValue(source, out var record))
            {
                record.set(value);
            }
            else
            {
                record = new GameEntityRecord();
                record.set(value);
                Collection.Add(source, record);
            }
        }

        public void set(int value, GameEntityIdentifier source, GameEntityIdentifier target)
        {
            Record.set(value);

            if (Collection.TryGetValue(source, out var record))
            {
                record.set(value, target);
            }
            else
            {
                record = new GameEntityRecord();
                record.set(value, target);
                Collection.Add(source, record);
            }
        }
        #endregion
    }
}
