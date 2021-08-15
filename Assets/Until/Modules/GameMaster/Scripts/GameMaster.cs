using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;


namespace until.modules.gamemaster
{
    public class GameMaster : Singleton<GameMaster>
    {
        #region Fields.
        private Dictionary<GameParameterIdentifier, GameParameterEntry> _ParameterCollection = new Dictionary<GameParameterIdentifier, GameParameterEntry>();
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
        /// パラメータ設定
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="affair"></param>
        /// <param name="value"></param>
        public void set(GameParameterIdentifier parameter, GameAffairIdentifier affair, int value = 0)
        {
            var entry = get(parameter, true);
            if (entry != null)
            {
                entry.set(affair, value);
            }
        }

        /// <summary>
        /// パラメータ設定
        /// </summary>
        /// <param name="source"></param>
        /// <param name="parameter"></param>
        /// <param name="affair"></param>
        /// <param name="value"></param>
        public void set(GameEntityIdentifier source, GameParameterIdentifier parameter, GameAffairIdentifier affair, int value = 0)
        {
            var entry = get(parameter, true);
            if (entry != null)
            {
                entry.set(source, affair, value);
            }
        }

        /// <summary>
        /// パラメータ設定
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="parameter"></param>
        /// <param name="affair"></param>
        /// <param name="value"></param>
        public void set(GameEntityIdentifier source, GameEntityIdentifier target, GameParameterIdentifier parameter, GameAffairIdentifier affair, int value = 0)
        {
            var entry = get(parameter, true);
            if (entry != null)
            {
                entry.set(source, target, affair, value);
            }
        }

        /// <summary>
        /// パラメータの取得
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="create">無いなら生成する</param>
        /// <returns></returns>
        private GameParameterEntry get(GameParameterIdentifier parameter, bool create)
        {
            if (_ParameterCollection.TryGetValue(parameter, out var entry))
            {
                return entry;
            }
            if (create)
            {
                entry = new GameParameterEntry(parameter);
                _ParameterCollection.Add(parameter, entry);
                return entry;
            }
            return null;

        }

        /// <summary>
        /// パラメータの取得
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public GameParameter get(GameParameterIdentifier parameter)
        {
            var entry = get(parameter, false);
            if (entry != null)
            {
                return entry.Parameter;
            }
            return null;
        }

        /// <summary>
        /// パラメータの取得
        /// </summary>
        /// <param name="source"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public GameParameter get(GameEntityIdentifier source, GameParameterIdentifier parameter)
        {
            var entry = get(parameter, false);
            if (entry == null)
            {
                return null;
            }
            return entry.get(source);
        }

        public GameParameter get(GameEntityIdentifier source, GameEntityIdentifier target, GameParameterIdentifier parameter)
        {
            var entry = get(parameter, false);
            if (entry == null)
            {
                return null;
            }
            return entry.get(source, target);
        }

        #endregion
        #endregion
    }
}
