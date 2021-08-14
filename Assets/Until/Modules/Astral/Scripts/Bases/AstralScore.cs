using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.astral
{
    public class AstralScore
    {
        #region Properties
        public string Name { get; private set; } = "";
        public AstralNote EntryPoint { get; private set; } = null;
        #endregion

        #region Fields
        /// <summary>ノートリスト</summary>
        private List<AstralNote> _Notes = new List<AstralNote>();
        #endregion

        #region Methods.
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AstralScore()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">名前</param>
        public AstralScore(string name)
        {
            Name = name;
        }

        /// <summary>
        /// ノートの追加
        /// </summary>
        /// <param name="note"></param>
        public void appendNote(AstralNote note, bool entry)
        {
            _Notes.Add(note);
            if (entry)
            {
                EntryPoint = note;
            }
        }
        #endregion
    }
}
