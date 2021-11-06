using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;
using until.develop;


namespace until.modules.bullet
{
    [DefaultExecutionOrder(system.defines.ExecutionOrder.Develop_Tail_00)]
    public class BulletClient : Behavior
    {
        #region MyRegion
        public string ButtleName
        {
            get => _BulletName;
        }
        #endregion

        #region Fiels.
        /// <summary>Bullet���BPrefab�̃t�@�C�����ƍ��킹�邱��</summary>
        [SerializeField]
        private string _BulletName = "";
        /// <summary>�A�j���[�^�[�ւ̎Q��</summary>
        private BulletAnimator _RefAnimator = null;
        #endregion

        #region Setup
        public void startBullet(BulletAnimator animator, Vector3 position)
        {
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
            var keepAlive = false;
            if (_RefAnimator != null)
            {
                keepAlive = _RefAnimator.onBulletUpdate(Time.deltaTime);
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
        }

        private void OnTriggerExit(Collider other)
        {
        }
        #endregion
    }
}

