using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace until.modules.gamemaster
{
    public class GameEntityEntry
    {
        public GameEntityIdentifier Identifier { get; private set; } = null;
        public GameParameter Parameter { get; private set; } = null;
        public Dictionary<GameEntityIdentifier, GameEntityEntry> TargetCollection = new Dictionary<GameEntityIdentifier, GameEntityEntry>();


        #region Methods
        /// <summary>
        /// コンストラクタ
        /// </summary>
        [Obsolete("Do not use default constructor.", true)]
        public GameEntityEntry()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="identifier"></param>
        public GameEntityEntry(GameEntityIdentifier entity, GameParameterIdentifier parameter)
        {
            Identifier = entity;
            Parameter = new GameParameter(parameter);
        }

        /// <summary>
        /// 値の設定
        /// </summary>
        /// <param name="affair"></param>
        /// <param name="value"></param>
        public void set(GameAffairIdentifier affair, int value)
        {
            Parameter.set(affair, value);
        }

        /// <summary>
        /// 値の設定(対象付き)
        /// </summary>
        /// <param name="target"></param>
        /// <param name="affair"></param>
        /// <param name="value"></param>
        public void set(GameEntityIdentifier target, GameAffairIdentifier affair, int value)
        {
            set(affair, value);

            if (TargetCollection.TryGetValue(target, out var entry))
            {
                entry.set(affair, value);
            }
            else
            {
                entry = new GameEntityEntry(target, Parameter.Identifier);
                entry.set(affair, value);
                TargetCollection.Add(target, entry);
            }
        }

        /// <summary>
        /// 値の取得
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public GameEntityEntry get(GameEntityIdentifier target)
        {
            if (TargetCollection.TryGetValue(target, out var entry))
            {
                return entry;
            }
            return null;
        }
        #endregion
    }
}
