using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace until.modules.gamemaster
{
    public class GameParameterEntry
    {
        #region Properties
        public GameParameterIdentifier Identifier { get; private set; } = null;
        public GameParameter Parameter { get; private set; } = null;
        #endregion

        #region Fields
        private Dictionary<GameEntityIdentifier, GameEntityEntry> OwnerList = new Dictionary<GameEntityIdentifier, GameEntityEntry>();
        #endregion

        #region Methods
        /// <summary>
        /// コンストラクタ
        /// </summary>
        [Obsolete("Do not use default constructor.", true)]
        public GameParameterEntry()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="identifier"></param>
        public GameParameterEntry(GameParameterIdentifier identifier)
        {
            Identifier = identifier;
            Parameter = new GameParameter(identifier);
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
        /// オーナー付きの値の設定
        /// </summary>
        /// <param name="source"></param>
        /// <param name="affair"></param>
        /// <param name="value"></param>
        public void set(GameEntityIdentifier source, GameAffairIdentifier affair, int value)
        {
            set(affair, value);

            if (OwnerList.TryGetValue(source, out var owner))
            {
                owner.set(affair, value);
            }
            else
            {
                owner = new GameEntityEntry(source, Parameter.Identifier);
                owner.set(affair, value);
                OwnerList.Add(source, owner);
            }
        }

        /// <summary>
        /// オーナー／対象付きの値の設定
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="affair"></param>
        /// <param name="value"></param>
        public void set(GameEntityIdentifier source, GameEntityIdentifier target, GameAffairIdentifier affair, int value)
        {
            set(affair, value);

            if (OwnerList.TryGetValue(source, out var owner))
            {
                owner.set(target, affair, value);
            }
            else
            {
                owner = new GameEntityEntry(source, Parameter.Identifier);
                owner.set(target, affair, value);
                OwnerList.Add(source, owner);
            }
        }

        /// <summary>
        /// 取得
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public GameParameter get(GameEntityIdentifier source)
        {
            if (OwnerList.TryGetValue(source, out var owner))
            {
                return owner.Parameter;
            }
            return null;
        }

        /// <summary>
        /// 取得
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public GameParameter get(GameEntityIdentifier source, GameEntityIdentifier target)
        {
            if (OwnerList.TryGetValue(source, out var entry) == false)
            {
                return null;
            }
            var target_entry = entry.get(target);
            if (target_entry == null)
            {
                return null;
            }
            return null;
        }


        #endregion
    }
}
