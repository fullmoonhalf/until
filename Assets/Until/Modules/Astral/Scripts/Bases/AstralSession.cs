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
        /// �R���X�g���N�^
        /// </summary>
        public AstralSession()
        {
        }

        #region �Z�b�g�A�b�v
        /// <summary>
        /// �G�������g�̊��蓖��
        /// </summary>
        /// <param name="role"></param>
        /// <param name="element"></param>
        public void assign(string role, AstralElement element)
        {
            _ElementCollection[role] = element;
        }

        /// <summary>
        /// �X�R�A�̊��蓖��
        /// </summary>
        /// <param name="score"></param>
        public void bind(AstralScore score)
        {
            _Score = score;
        }
        #endregion

        #region �Z�b�V�������s
        /// <summary>
        /// �Z�b�V����������
        /// </summary>
        public void init()
        {
            Log.info(this, "init");
            _NextNote = _Score.EntryPoint;
        }

        /// <summary>
        /// �Z�b�V�����X�V
        /// </summary>
        /// <returns>�Z�b�V�������p�����ׂ��ꍇ�� true�B�����łȂ��ꍇ�� false</returns>
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
        /// �I������
        /// </summary>
        public void exit()
        {
            Log.info(this, "exit");
        }
        #endregion

        #region �C���X�g���N�V�����Z�b�g
        /// <summary>
        /// �s���J�n�̃��N�G�X�g
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
        /// �s���I���̃��N�G�X�g
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

