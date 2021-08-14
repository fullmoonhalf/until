using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace until.modules.astral
{
    public abstract class AstralWorld
    {
        #region Definitions
        public abstract AstralSpace getSpace(int id);
        public abstract AstralBody getBody(int id);
        public abstract IEnumerable<AstralBody> getUpdatableBodies();
        #endregion

        #region Fields
        private List<AstralSession> _RegistedSessionList = new List<AstralSession>();
        private List<AstralSession> _ActiveSessionList = new List<AstralSession>();
        #endregion

        #region Methods.
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public AstralWorld()
        {
        }


        public void onAstralUpdate()
        {
            // �Z�b�V�����̍X�V
            foreach (var session in _RegistedSessionList)
            {
                session.init();
                _ActiveSessionList.Add(session);
            }
            _RegistedSessionList.Clear();
            _ActiveSessionList.RemoveAll(session =>
            {
                var keepAlive = session.update();
                if (keepAlive == false)
                {
                    session.exit();
                }
                return !keepAlive;
            });
        }

        /// <summary>
        /// �Z�b�V�����̓o�^
        /// </summary>
        /// <param name="session"></param>
        public void regist(AstralSession session)
        {
            _RegistedSessionList.Add(session);
        }
        #endregion
    }
}

