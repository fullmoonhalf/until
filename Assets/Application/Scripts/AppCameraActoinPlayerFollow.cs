using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;
using until.modules.camera;
using until.modules.gamemaster;
using until.modules.gamefield;
using until.utils;
using until.develop;


namespace until.test
{
    public class AppCameraActoinPlayerFollow : CameraAction
    {
        #region Settings
        private Vector3 _CameraPosition = Vector3.zero;
        private Vector3 _TargetOffset = Vector3.up;
        private float _RotationSpeed = 120.0f;
        #endregion

        #region Fields.
        private float _Distance = 2.0f;
        private float _YawDegree = 0.0f;
        private float _PitchDegree = 0.0f;
        public Quaternion _Rotation = Quaternion.identity;
        private Substance _TargetSubstance = null;
        #endregion

        #region CameraAction
        public Vector3 Position => _CameraPosition;
        public Quaternion Rotation => _Rotation;
        public float FoV => 60.0f;
        public bool Orthographic => false;


        private Vector3 calcCameraPosition(Vector3 target_position, Vector3 target_offset, float distance, float yaw_degree, float pitch_degree)
        {
            var gap = Vector3.forward * distance;
            var rotation = Quaternion.Euler(pitch_degree, yaw_degree, 0.0f);
            var camera_offset = rotation * gap;
            var camera_position = target_position + target_offset + camera_offset;
            return camera_position;
        }

        private Quaternion calcCameraRotation(Vector3 camera_position, Vector3 focus_position)
        {
            var forward = focus_position - camera_position;
            return Quaternion.LookRotation(forward);
        }

        public void onSwitchingStart(CameraActionArgument argument)
        {
            _TargetSubstance = Singleton.SubstanceManager.get(new GameEntitySerializableIdentifier("0"));
            if (_TargetSubstance != null)
            {
                _CameraPosition = calcCameraPosition(_TargetSubstance.Position, _TargetOffset, _Distance, _YawDegree, _PitchDegree);
                _Rotation = calcCameraRotation(_CameraPosition, _TargetSubstance.Position + _TargetOffset);
            }
            else
            {
                _CameraPosition = new Vector3(0.0f, 100.0f, 0.0f);
                _Rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
            }
        }

        public void onSwitchingEnd()
        {
        }

        public void onUpdate(float deltaTime)
        {
            var stickL = Singleton.InputManager.getStick(InputPad.Player1, InputStickType.R);
            var yaw_speed = _RotationSpeed * stickL.X * deltaTime;
            var pitch_speed = _RotationSpeed * stickL.Y * deltaTime;
            _YawDegree = math.getDegreeArgument(_YawDegree + yaw_speed);
            var pitch = math.getDegreeArgument(_PitchDegree + pitch_speed);
            _PitchDegree = Mathf.Clamp(pitch, -45.0f, 45.0f);
            _CameraPosition = calcCameraPosition(_TargetSubstance.Position, _TargetOffset, _Distance, _YawDegree, _PitchDegree);
            _Rotation = calcCameraRotation(_CameraPosition, _TargetSubstance.Position + _TargetOffset);
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

