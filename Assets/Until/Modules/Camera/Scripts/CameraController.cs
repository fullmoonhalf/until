using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;
using until.develop;
using until.utils;

namespace until.modules.camera
{
    [DefaultExecutionOrder(system.defines.ExecutionOrder.System_Head_50)]
    public class CameraController : Behavior
    {
        #region Properties
        public Vector3 Position { get; private set; } = Vector3.zero;
        public Quaternion Rotation { get; private set; } = Quaternion.identity;
        public float FoV { get; private set; } = 0.0f;
        public CameraAction CurrentAction { get => _CurrentAction; }
        #endregion

        #region Fields.
        private Camera _RefCameraComponent = null;
        private CameraAction _CurrentAction = null;
        private CameraAction _PreviousAction = null;
        private CameraAction _NextAction = null;
        private float _InterpolationTime = 0.0f;
        private float _InterpolationCount = 0.0f;
        #endregion

        #region Behavior
        // Start is called before the first frame update
        void Start()
        {
            _RefCameraComponent = gameObject.GetComponent<Camera>();
            Singleton.CameraManager.regist(this);
        }

        // Update is called once per frame
        void Update()
        {
            // �؂�ւ��J�n
            if (_NextAction != null)
            {
                Log.info(this, $"switching camera {_CurrentAction} -> {_NextAction}");
                _PreviousAction = _CurrentAction;
                _CurrentAction = _NextAction;
                _NextAction = null;
                _InterpolationCount = math.EPSILON;

                _PreviousAction?.onReplacedStart();
                _CurrentAction?.onSwitchingStart();
            }

            // ���ꂼ��̏����̍X�V
            var deltaTime = Mathf.Max(Time.deltaTime, math.EPSILON);
            _PreviousAction?.onUpdate(deltaTime);
            _CurrentAction?.onUpdate(deltaTime);

            var currentCameraPosition = _CurrentAction?.Position ?? Vector3.zero;
            var currentCameraRotation = _CurrentAction?.Rotation ?? Quaternion.identity;
            var currentCameraFov = _CurrentAction?.FoV ?? 0.0f;
            var currentOrthographic = _CurrentAction?.Orthographic ?? false;

            // ��ԏ���
            if (_InterpolationCount > 0.0f)
            {
                _InterpolationCount += deltaTime;
                var t = Mathf.Clamp01(_InterpolationCount / _InterpolationTime);
                var previousCameraPosition = _PreviousAction?.Position ?? Vector3.zero;
                var previousCameraRotation = _PreviousAction?.Rotation ?? Quaternion.identity;
                currentCameraPosition = Vector3.Lerp(previousCameraPosition, currentCameraPosition, t);
                currentCameraRotation = Quaternion.Slerp(previousCameraRotation, currentCameraRotation, t);

                // ��ԏI������
                if (_InterpolationCount >= _InterpolationTime)
                {
                    _PreviousAction?.onReplacedEnd();
                    _CurrentAction?.onSwitchingEnd();
                    _PreviousAction = null;
                    _InterpolationCount = 0.0f;
                    _InterpolationTime = 0.0f;
                }
            }

            // �ʒu�̔��f
            if (_RefCameraComponent != null)
            {
                Position = currentCameraPosition;
                Rotation = currentCameraRotation;
                FoV = currentCameraFov;
                _RefCameraComponent.transform.localPosition = currentCameraPosition;
                _RefCameraComponent.transform.localRotation = currentCameraRotation;
                _RefCameraComponent.fieldOfView = currentCameraFov;
                _RefCameraComponent.orthographic = currentOrthographic;
            }
        }

        private void OnDestroy()
        {
            Singleton.CameraManager.unregist(this);
        }
        #endregion

        #region Request
        /// <summary>
        /// �J�����J��
        /// </summary>
        /// <param name="nextAction"></param>
        /// <param name="interpolation"></param>
        public void transitCamera(CameraAction nextAction, float interpolation = 0.0f)
        {
            Log.info(this, $"transitCamera requested {nextAction} interpolation={interpolation}");
            _NextAction = nextAction;
            _InterpolationTime = Mathf.Max(interpolation, 0.0f) + math.EPSILON; // 0 �Ƃ����ʓ|�Ȃ̂Ŕ����l�𑫂��Ă�B
        }
        #endregion
    }
}

