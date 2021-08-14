using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace until.modules.astral.note
{
    public class EndBehavior : AstralNote
    {
        #region Defines
        public override AstralNoteOpcode Opcode => new AstralNoteOpcode(AstralNoteOpcodeMnemonic.EndBehavior);

        private class Context : AstralNoteContext
        {
            private EndBehavior _Note = null;
            private AstralBehaviorRequest _Request = null;
            private bool _ActionEnd = false;

            public Context(EndBehavior note)
            {
                _Note = note;
            }

            public override void init(AstralSession session)
            {
                _Request = new AstralBehaviorRequest();
                _Request.Identifier = _Note.Identifier;
                _Request.onAccepted += onAccept;
                _Request.onRejected += onReject;
                _Request.onCompeleted += onComplete;
                session.requestEndAction(_Note.Role, _Request);
            }

            public override bool update(AstralSession session)
            {
                return _ActionEnd;
            }

            public override AstralNote exit(AstralSession session)
            {
                return null;
            }

            public void onAccept()
            {
            }

            public void onReject()
            {
                _ActionEnd = true;
            }

            public void onComplete()
            {
                _ActionEnd = true;
            }
        }
        #endregion

        #region Properties
        public string Role { get; private set; } = "";
        public AstralBehaviorIdentifier Identifier { get; private set; } = null;
        #endregion

        #region Methods.
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EndBehavior()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="role"></param>
        /// <param name="identifier"></param>
        public EndBehavior(string role, AstralBehaviorIdentifier identifier)
        {
            Role = role;
            Identifier = identifier;
        }

        #region AstralNote
        /// <summary>
        /// 実行コンテキストの生成
        /// </summary>
        /// <returns></returns>
        public override AstralNoteContext createContext()
        {
            return new Context(this);
        }
        #endregion
        #endregion
    }
}

