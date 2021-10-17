using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using until.system;


namespace until.test
{
    public class IngameField : Singleton<IngameField>
    {
        #region Fields.
        private bool _LevelLoading = false;
        private bool _LevelUnloading = false;
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
        #region Level
        public void enterLevel(int id)
        {
            _LevelLoading = true;
            Singleton.SceneLoader.requestToLoad(2, () => _LevelLoading = false);
            Singleton.PrefabInstantiateMediator.requestFromCollection("Ch01000", onCharacterInstantiated);
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
        }
        #endregion
        #endregion
    }
}
