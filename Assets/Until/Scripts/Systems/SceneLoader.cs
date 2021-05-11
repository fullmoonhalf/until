using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using until.develop;


namespace until.system.singleton
{
    [DisallowMultipleComponent]
    public class SceneLoader : Singleton<SceneLoader>
    {
        #region Definition
        public enum Phase
        {
            Unload,
            Activating,
            Active,
            Deactivating,
        }
        public enum Target
        {
            Unload,
            Active,
        }

        private class SceneController
        {
            public int SceneIndex { get; private set; }
            public string SceneName { get; private set; }

            private Phase CurrentPhase = Phase.Unload;
            private AsyncOperation SceneLoadingStatus = null;
            private Action AfterLoadAction = null;
            private Action AfterUnloadAction = null;
            private Scene TargetScene;

            public SceneController(int index, Scene scene)
            {
                SceneIndex = index;
                TargetScene = scene;
                SceneName = TargetScene.name;
            }

            #region Process Control
            public bool onUpdate()
            {
                var finish = false;

                switch (CurrentPhase)
                {
                    case Phase.Unload:
                        if (AfterUnloadAction != null)
                        {
                            AfterUnloadAction.Invoke();
                            AfterUnloadAction = null;
                            finish = true;
                        }
                        if (AfterLoadAction != null)
                        {
                            transit(Phase.Activating);
                            SceneLoadingStatus = SceneManager.LoadSceneAsync((int)SceneIndex, LoadSceneMode.Additive);
                            finish = false;
                        }
                        break;
                    case Phase.Activating:
                        if (SceneLoadingStatus.isDone)
                        {
                            SceneLoadingStatus = null;
                            transit(Phase.Active);
                        }
                        break;
                    case Phase.Active:
                        if (AfterLoadAction != null)
                        {
                            AfterLoadAction.Invoke();
                            AfterLoadAction = null;
                            finish = true;
                        }
                        if (AfterUnloadAction != null)
                        {
                            transit(Phase.Deactivating);
                            SceneLoadingStatus = SceneManager.UnloadSceneAsync((int)SceneIndex);
                            finish = false;
                        }
                        break;
                    case Phase.Deactivating:
                        if (SceneLoadingStatus.isDone)
                        {
                            SceneLoadingStatus = null;
                            transit(Phase.Deactivating);
                        }
                        break;
                }

                return finish;
            }

            private void transit(Phase NextPhase)
            {
                CurrentPhase = NextPhase;
            }
            #endregion

            #region Request
            public void requestToLoad(Action Callback)
            {
                AfterLoadAction += Callback;
            }

            public void requestToUnload(Action Callback)
            {
                AfterUnloadAction += Callback;
            }
            #endregion

            #region Hash
            public override int GetHashCode()
            {
                return SceneIndex.GetHashCode() ^ base.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                if (obj is SceneController controller)
                {
                    return SceneIndex == controller.SceneIndex;
                }
                return false;
            }
            #endregion
        }
        #endregion

        #region Properties.
        #endregion

        #region Member.
        private SceneController[] _SceneCollection = null;
        private HashSet<SceneController> _ActiveSceneCollection = new HashSet<SceneController>();
        private Action _NullAction = () => { };
        #endregion


        #region Methods.
        #region sigleton
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

        #region Process Control
        // Update is called once per frame
        public void onUpdate()
        {
            _ActiveSceneCollection.RemoveWhere(control => control.onUpdate());
        }
        #endregion

        #region Control from application
        public void startManagement(int scene_count)
        {
            // シーンリストの生成
            _SceneCollection = new SceneController[scene_count];
            for (int scene_index = 0; scene_index < scene_count; ++scene_index)
            {
                var scene = SceneManager.GetSceneByBuildIndex(scene_index);
                var control = new SceneController(scene_index, scene);
                _SceneCollection[scene_index] = control;
                Log.info(this, $"[{scene_index}]{control.SceneName} is registed.");
            }
        }

        public void endManagement()
        {
            _SceneCollection = null;
        }
        #endregion

        #region Requests
        /// <summary>
        /// receive scene load request.
        /// </summary>
        /// <param name="SceneIdentifier"></param>
        /// <param name="callback"></param>
        public void requestToLoad(int scene_index, Action callback = null)
        {
            var controller = getSceneController(scene_index);
            if (controller != null)
            {
                Log.info(this, $"requestToLoad {scene_index}");
                controller.requestToLoad(callback ?? _NullAction);
                _ActiveSceneCollection.Add(controller);
            }
        }

        /// <summary>
        /// receive scene unload request.
        /// </summary>
        /// <param name="SceneIdentifier"></param>
        /// <param name="callback"></param>
        public void requestToUnload(int scene_index, Action callback = null)
        {
            var controller = getSceneController(scene_index);
            if (controller != null)
            {
                Log.info(this, $"requestToUnload {scene_index}");
                controller.requestToUnload(callback ?? _NullAction);
                _ActiveSceneCollection.Add(controller);
            }
        }

        /// <summary>
        /// getting scene control object.
        /// </summary>
        /// <param name="SceneIdentifier"></param>
        /// <returns></returns>
        private SceneController getSceneController(int scene_index)
        {
            return _SceneCollection[scene_index];
        }
        #endregion
        #endregion
    }
}
