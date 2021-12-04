using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.system;


namespace until.test
{
    public class IngameField : Singleton<IngameField>
    {
        #region Fields.
        private bool _LevelLoading = false;
        private bool _LevelUnloading = false;
        private GameObject _PlayerObject = null;
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
        }
        #endregion

        #region Methods
        #region Behavior
        public void onStart()
        {
        }

        public void onUpdate()
        {
            if (_PlayerObject != null)
            {
                var stick = Singleton.InputManager.getStick(InputPad.Player1, InputStickType.L);
                if (stick != null)
                {
                    var position = _PlayerObject.transform.position;
                    position.x += stick.X * 0.01f;
                    position.z += stick.Y * 0.01f;
                    _PlayerObject.transform.position = position;
                }
            }
        }

        public void onDestroy()
        {
        }
        #endregion


        #region Level
        public void enterLevel(int id)
        {
            _LevelLoading = true;
            Singleton.SceneLoader.requestToLoad(2, () => _LevelLoading = false);
            Singleton.PrefabInstantiateMediator.requestFromCollection("Ch01000", onCharacterInstantiated);
            Singleton.PrefabInstantiateMediator.requestFromCollection("Ch01001", onCharacterInstantiated);
            Singleton.CameraManager.transitCamera<IngamePlayCamera>();
        }

        public void leaveLevel(int id)
        {
            _LevelUnloading = true;
            Singleton.SceneLoader.requestToUnload(2, () => _LevelUnloading = false); // 仮
        }

        public bool checkUnderControlLevelScene()
        {
            return _LevelLoading | _LevelUnloading;
        }


        private void onCharacterInstantiated(PrefabInstantiateMediator.Result result, UnityEngine.Object go)
        {
            if (result != PrefabInstantiateMediator.Result.Success)
            {
                return;
            }

            var gameobj = go as GameObject;
            if (gameobj == null)
            {
                return;
            }
            var character = gameobj.GetComponent<SubstanceCharacter>();
            if (character == null)
            {
                return;
            }
            switch (character.CharacterID)
            {
                case CharacterID.Ch1000:
                    _PlayerObject = go as GameObject;
                    break;
                case CharacterID.Ch1001:
                    _PlayerObject.transform.position = Vector3.one;
                    break;
            }
        }
        #endregion
        #endregion
    }
}
