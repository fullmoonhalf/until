using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;
using until.modules.camera;


namespace until.singleton
{
    public class CameraManager : Singleton<CameraManager>
    {
        #region Field.
        private CameraController RefCameraController = null;
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

        #region manamgement
        public void regist(CameraController camera)
        {
            RefCameraController = camera;
        }

        public void unregist(CameraController camera)
        {
            RefCameraController = null;
        }
        #endregion

        #region Request.
        /// <summary>
        /// カメラ遷移
        /// </summary>
        /// <param name="nextAction"></param>
        /// <param name="interpolation"></param>
        public void transitCamera<T>(float interpolation = 0.0f) where T : CameraAction, new()
        {
            if (RefCameraController != null)
            {
                var nextAction = new T(); //TODO: そのうち  cache を使う形に直す
                RefCameraController.transitCamera(nextAction, interpolation);
            }
        }
        #endregion

        #region Status
        /// <summary>
        /// 現在位置取得
        /// </summary>
        /// <returns></returns>
        public Vector3 getPosition()
        {
            return (RefCameraController != null) ? RefCameraController.Position : Vector3.zero;
        }

        /// <summary>
        /// 現在向き取得
        /// </summary>
        /// <returns></returns>
        public Quaternion getRotation()
        {
            return (RefCameraController != null) ? RefCameraController.Rotation : Quaternion.identity;
        }
        #endregion
    }
}


