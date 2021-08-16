using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace until.modules.astral.note
{
    public class BeginBehavior : AstralNote
    {
        #region Defines
        public override AstralNoteOpcode Opcode => new AstralNoteOpcode(AstralNoteOpcodeMnemonic.BeginBehavior);


        private class Context : AstralNoteContext
        {
            private BeginBehavior _Note = null;
            private AstralBehaviorRequest _Request = null;
            private bool _KeepAlive = true;

            public Context(BeginBehavior note)
            {
                _Note = note;
            }

            public override void init(AstralSession session)
            {
                _Request = new AstralBehaviorRequest(_Note.Operation.createArgument());
                _Request.Identifier = _Note.Operation;
                _Request.onAcceptEvent += onAccept;
                _Request.onRejectedEvent += onReject;
                _Request.onCompeletedEvent += onComplete;
                session.requestBeginAction(_Note.Role, _Request);
            }

            public override bool update(AstralSession session)
            {
                return _KeepAlive;
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
                _KeepAlive = false;
            }

            public void onComplete()
            {
                _KeepAlive = false;
            }
        }
        #endregion

        #region Properties
        public string Role { get; private set; } = "";
        public AstralBehaviorOperation Operation { get; private set; } = null;
        #endregion

        #region Methods.
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BeginBehavior()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="role"></param>
        /// <param name="identifier"></param>
        public BeginBehavior(string role, AstralBehaviorOperation identifier)
        {
            Role = role;
            Operation = identifier;
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

