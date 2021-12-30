using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;
using until.develop;


namespace until.modules.bullet
{
    [DefaultExecutionOrder(until.system.settings.UntilBehaviorOrder.Bullet_BulletClient)]
    public class BulletClient : Behavior
    {
        #region Properties
        public string ButtleName
        {
            get => _BulletName;
        }
        public Vector3 BulletPosition => transform.position;
        /// <summary>����</summary>
        public BulletParameter _Attribute { get; private set; } = null;
        #endregion

        #region Fiels.
        /// <summary>Bullet���BPrefab�̃t�@�C�����ƍ��킹�邱��</summary>
        [SerializeField]
        private string _BulletName = "";
        /// <summary>�A�j���[�^�[�ւ̎Q��</summary>
        private BulletAnimator _RefAnimator = null;
        /// <summary>�I�����N�G�X�g</summary>
        private bool _RequestToFinish = false;
        #endregion

        #region Setup
        public void startBullet(BulletAnimator animator, Vector3 position, BulletParameter attribute)
        {
            _Attribute = attribute;
            _RequestToFinish = false;
            _RefAnimator = animator;
            _RefAnimator.onBulletStart();
            transform.position = position;
        }
        #endregion

        #region Behavior
        private void Start()
        {
        }

        private void Update()
        {
            var keepAlive = !_RequestToFinish;
            if (_RefAnimator != null)
            {
                keepAlive &= _RefAnimator.onBulletUpdate(Time.deltaTime);
                transform.position += _RefAnimator.getDeltaBulletPosition();
            }
            if (!keepAlive)
            {
                Singleton.BulletManager.back(this);
            }
        }
        #endregion

        #region Trigger
        private void OnTriggerEnter(Collider other)
        {
        }

        private void OnTriggerStay(Collider other)
        {
            var target = other.GetComponent<BulletTarget>();
            if (target == null)
            {
                return;
            }
            target.onContactBullet(this);
        }

        private void OnTriggerExit(Collider other)
        {
        }
        #endregion

        #region Control
        public void requestToFinish()
        {
            _RequestToFinish = true;
        }
        #endregion
    }
}

