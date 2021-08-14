using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;


namespace until.modules.gamemaster
{
    public class GameMaster : Singleton<GameMaster>
    {
        #region Fields.
        private Dictionary<GameAffairIdentifier, GameAffairRecord> _Records = new Dictionary<GameAffairIdentifier, GameAffairRecord>();
        #endregion

        #region Methods
        #region Singleton
        public override void onSingletonAwake()
        {
        }

        public override void onSingletonStart()
        {
        }

        public override void onSingletonDestroy()
        {
        }
        #endregion


        #region Affair
        /// <summary>
        /// 値の設定
        /// </summary>
        /// <param name="affair"></param>
        /// <param name="value"></param>
        public void set(GameAffairIdentifier affair, int value = 0)
        {
            var record = get(affair);
            if (record == null)
            {
                return;
            }
            record.set(value);
        }

        /// <summary>
        /// 値の設定
        /// </summary>
        /// <param name="affair"></param>
        /// <param name="source"></param>
        /// <param name="value"></param>
        public void set(GameAffairIdentifier affair, GameEntityIdentifier source, int value = 0)
        {
            var record = get(affair);
            if (record == null)
            {
                return;
            }
            record.set(value, source);
        }

        /// <summary>
        /// 値の設定
        /// </summary>
        /// <param name="affair"></param>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public void set(GameAffairIdentifier affair, GameEntityIdentifier source, GameEntityIdentifier target, int value = 0)
        {
            var record = get(affair);
            if (record == null)
            {
                return;
            }
            record.set(value, source, target);
        }

        /// <summary>
        /// 値の取得
        /// </summary>
        /// <param name="affair"></param>
        /// <returns></returns>
        public GameAffairRecord get(GameAffairIdentifier affair)
        {
            if (_Records.TryGetValue(affair, out var record))
            {
                return record;
            }
            return null;
        }
        #endregion


        #endregion
    }
}
