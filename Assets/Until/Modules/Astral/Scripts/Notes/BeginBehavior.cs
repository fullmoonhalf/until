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
            private bool _ActionEnd = false;

            public Context(BeginBehavior note)
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
                session.requestBeginAction(_Note.Role, _Request);
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
        /// �R���X�g���N�^
        /// </summary>
        public BeginBehavior()
        {
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="role"></param>
        /// <param name="identifier"></param>
        public BeginBehavior(string role, AstralBehaviorIdentifier identifier)
        {
            Role = role;
            Identifier = identifier;
        }

        #region AstralNote
        /// <summary>
        /// ���s�R���e�L�X�g�̐���
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

