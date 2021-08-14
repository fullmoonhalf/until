using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.develop;



namespace until.modules.astral
{
    public class AstralSession
    {
        #region Fields
        private Dictionary<string, AstralElement> _ElementCollection = new Dictionary<string, AstralElement>();
        private AstralScore _Score = null;
        private AstralNote _NextNote = null;
        private AstralNoteContext _CurrentNote = null;
        #endregion

        #region Methods.
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AstralSession()
        {
        }

        #region セットアップ
        /// <summary>
        /// エレメントの割り当て
        /// </summary>
        /// <param name="role"></param>
        /// <param name="element"></param>
        public void assign(string role, AstralElement element)
        {
            _ElementCollection[role] = element;
        }

        /// <summary>
        /// スコアの割り当て
        /// </summary>
        /// <param name="score"></param>
        public void bind(AstralScore score)
        {
            _Score = score;
        }
        #endregion

        #region セッション実行
        /// <summary>
        /// セッション初期化
        /// </summary>
        public void init()
        {
            Log.info(this, "init");
            _NextNote = _Score.EntryPoint;
        }

        /// <summary>
        /// セッション更新
        /// </summary>
        /// <returns>セッションを継続すべき場合は true。そうでない場合は false</returns>
        public bool update()
        {
            if (_CurrentNote == null)
            {
                if (_NextNote != null)
                {
                    _CurrentNote = _NextNote.createContext();
                    if (_CurrentNote != null)
                    {
                        _CurrentNote.init(this);
                    }
                }
            }

            if (_CurrentNote != null)
            {
                if (_CurrentNote.update(this) == false)
                {
                    _NextNote = _CurrentNote.exit(this);
                    _CurrentNote = null;
                }
            }

            return (_CurrentNote != null || _NextNote != null);
        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public void exit()
        {
            Log.info(this, "exit");
        }
        #endregion

        #region インストラクションセット
        /// <summary>
        /// 行動開始のリクエスト
        /// </summary>
        /// <param name="key"></param>
        /// <param name="request"></param>
        public void requestBeginAction(string key, AstralBehaviorRequest request)
        {
            if (_ElementCollection.TryGetValue(key, out var element))
            {
                element.requestBehaviorStart(request);
            }
        }

        /// <summary>
        /// 行動終了のリクエスト
        /// </summary>
        /// <param name="key"></param>
        /// <param name="request"></param>
        public void requestEndAction(string key, AstralBehaviorRequest request)
        {
            if (_ElementCollection.TryGetValue(key, out var element))
            {
                element.requestBehaviorEnd(request);
            }
        }
        #endregion
        #endregion
    }
}

