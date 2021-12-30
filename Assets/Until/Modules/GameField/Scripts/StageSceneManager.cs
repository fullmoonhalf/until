using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;
using until.develop;



namespace until.modules.gamefield
{
    public class StageSceneManager : Singleton<StageSceneManager>
    {
        #region Properties
        /// <summary>���݃V�[���}�l�[�W���[�����������ǂ���</summary>
        public bool IsProcessing => _ActiveControllers.Count > 0;
        /// <summary>�S�Ă� unload �̏�Ԃ��ǂ���</summary>
        public bool IsAllUnloaded
        {
            get
            {
                foreach (var controller in _ControllerCollection.Values)
                {
                    if (!controller.IsUnload)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        #endregion

        #region Fields.
        private Dictionary<StageIdentifier, StageSceneController> _ControllerCollection = new Dictionary<StageIdentifier, StageSceneController>();
        private HashSet<StageSceneController> _ActiveControllers = new HashSet<StageSceneController>();
        #endregion

        #region Singleton
        public override void onSingletonAwake()
        {
        }

        public override void onSingletonStart()
        {
        }

        public override void onSingletonDestroy()
        {
            _ControllerCollection.Clear();
            _ActiveControllers.Clear();
        }
        #endregion

        #region Methods
        #region Behavior
        public void onStart()
        {
        }

        public void onUpdate()
        {
            _ActiveControllers.RemoveWhere(controller => controller.update());
        }

        public void onDestroy()
        {
        }
        #endregion

        #region Request
        public void request(StageIdentifier identifier, StageSceneStatus target)
        {
            if (_ControllerCollection.TryGetValue(identifier, out var controller))
            {
                controller.requestTarget(target);
                _ActiveControllers.Add(controller);
            }
        }

        /// <summary>
        /// �Sunload
        /// </summary>
        public void requestToUnloadAll()
        {
            foreach (var controller in _ControllerCollection.Values)
            {
                controller.requestTarget(StageSceneStatus.Unload);
                _ActiveControllers.Add(controller);
            }
        }
        #endregion

        #region Management
        /// <summary>
        /// �o�^
        /// </summary>
        /// <param name="controller"></param>
        public void regist(StageSceneController controller)
        {
            Log.info(this, $"{controller.Identifier} regist");
            _ControllerCollection[controller.Identifier] = controller;
        }

        /// <summary>
        /// �o�^����
        /// </summary>
        /// <param name="controller"></param>
        public void unregist(StageSceneController controller)
        {
            _ControllerCollection.Remove(controller.Identifier);
        }
        #endregion
        #endregion
    }
}

