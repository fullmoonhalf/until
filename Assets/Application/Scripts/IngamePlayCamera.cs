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
        #endregion

        #region CameraAction
        public Vector3 Position => _Position;
        public Quaternion Rotation => _Rotation;
        public float FoV => 60.0f;
        public bool Orthographic => false;

        public void onSwitchingStart()
        {
            _Position = new Vector3(0.0f, 10.0f, 0.0f);
            _Rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
        }

        public void onSwitchingEnd()
        {
        }

        public void onUpdate(float deltaTime)
        {
        }

        public void onReplacedStart()
        {
        }

        public void onReplacedEnd()
        {
        }

        #endregion
    }
}

