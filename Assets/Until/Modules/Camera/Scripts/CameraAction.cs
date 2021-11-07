using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.camera
{
    public interface CameraAction
    {
        public Vector3 Position { get; }
        public Quaternion Rotation { get; }
        public float FoV { get; }
        public bool Orthographic { get; }

        public void onSwitchingStart();
        public void onSwitchingEnd();
        public void onReplacedStart();
        public void onReplacedEnd();
        public void onUpdate(float deltaTime);
    }
}
