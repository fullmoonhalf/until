using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.develop;


namespace until.modules.gamefield
{
    public class StageSceneController
    {
        #region Defines
        private enum Phase
        {
            Unload,
            Loading,
            Unloading,
            Loaded,
        }
        #endregion

        #region Properties
        /// <summary>�^�[�Q�b�g��Ԃɑ΂��Ĉ���ȏ�Ԃ��ǂ���</summary>
        public bool IsTargetComplete
        {
            get
            {
                switch (TargetStatus)
                {
                    case StageSceneStatus.Active:
                        return IsActive;
                    case StageSceneStatus.Unload:
                        return IsUnload;
                }
                return false;
            }
        }

        public bool IsActive => _CurrentPhase == Phase.Loaded;
        public bool IsUnload => _CurrentPhase == Phase.Unload;
        #endregion

        #region Fields.
        public StageIdentifier Identifier { get; private set; } = null;
        public StageSceneStatus TargetStatus { get; private set; } = StageSceneStatus.Unload;
        private int _SceneIndex = 0;
        private Phase _CurrentPhase = Phase.Unload;
        #endregion

        #region Methods
        /// <summary>
        /// �R���X�g���N�^(�f�t�H���g�͎g�p�֎~)
        /// </summary>
        [Obsolete]
        public StageSceneController()
        {
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="identifier">�X�e�[�W���ʎq</param>
        /// <param name="scene_index">�V�[���C���f�b�N�X</param>
        public StageSceneController(StageIdentifier identifier, int scene_index)
        {
            Identifier = identifier;
            _SceneIndex = scene_index;
        }
        #endregion

        #region Requests
        public void requestTarget(StageSceneStatus target)
        {
            Log.info(this, $"requestTarget {Identifier} {TargetStatus} > {target}");
            TargetStatus = target;
        }
        #endregion

        #region Process
        /// <summary>
        /// �X�V�����B
        /// </summary>
        /// <returns>�X�V�I�����Ă����Ȃ� true ��Ԃ�</returns>
        public bool update()
        {
            switch (_CurrentPhase)
            {
                case Phase.Unload:
                    if (TargetStatus == StageSceneStatus.Unload)
                    {
                        return true;
                    }
                    transit(Phase.Loading);
                    Singleton.SceneLoader.requestToLoad(_SceneIndex, () => transit(Phase.Loaded));
                    break;
                case Phase.Loading:
                    break;
                case Phase.Loaded:
                    if (TargetStatus == StageSceneStatus.Active)
                    {
                        return true;
                    }
                    transit(Phase.Unloading);
                    Singleton.SceneLoader.requestToUnload(_SceneIndex, () => transit(Phase.Unload));
                    break;
                case Phase.Unloading:
                    break;
            }
            return false;
        }

        private void transit(Phase next_phase)
        {
            Log.info(this, $"transit {Identifier} {_CurrentPhase} > {next_phase}");
            _CurrentPhase = next_phase;
        }
        #endregion
    }
}