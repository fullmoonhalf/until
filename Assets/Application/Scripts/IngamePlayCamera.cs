using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.modules.camera;


namespace until.test
{
    public class IngamePlayCamera : CameraAction
    {
        #region Properties
        #endregion

        #region Fields
        private Vector3 _Position = Vector3.zero;
        public Quaternion _Rotation = Quaternion.identity;
        public float FoV => 60.0f;
        public bool Orthographic => false;
        #endregion

        #region CameraAction
        public Vector3 Position => _Position;
        public Quaternion Rotation => _Rotation;

        public void onReplacedStart()
        {
        }

        public void onReplacedEnd()
        {
        }

        public void onSwitchingStart()
        {
        }

        public void onSwitchingEnd()
        {
        }

        public void onUpdate(float deltaTime)
        {
        }
        #endregion
    }
}

