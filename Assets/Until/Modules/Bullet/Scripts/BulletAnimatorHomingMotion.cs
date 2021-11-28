using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;



namespace until.modules.bullet
{
    public class BulletAnimatorHomingMotion : BulletAnimator
    {
        #region Fields
        private BulletClient _RefBullet = null;
        private BulletTarget _RefTarget = null;
        private float _Speed = 0.0f;
        private float _Life = float.MaxValue;
        private float _Age = 0.0f;
        private Vector3 _CurrentMoveAmount = Vector3.zero;
        #endregion

        #region Methods
        #region Constructor
        public BulletAnimatorHomingMotion(BulletClient bullet, BulletTarget target, float speed, float life)
        {
            _RefBullet = bullet;
            _RefTarget = target;
            _Speed = speed;
            _Life = life;
        }
        #endregion

        #region BulletAnimator
        public void onBulletStart()
        {
        }

        public bool onBulletUpdate(float elapsed)
        {
            var difference = _RefTarget.BulletTargetPosotion - _RefBullet.BulletPosition;
            var distance = difference.magnitude;
            var amount = _Speed * elapsed;
            if (distance > amount)
            {
                _CurrentMoveAmount = difference * amount / distance;
            }
            else if (distance > 0.0f)
            {
                _CurrentMoveAmount = difference;
            }
            else
            {
                _CurrentMoveAmount = Vector3.zero;
            }

            _Age += elapsed;
            return _Age < _Life;
        }

        public Vector3 getDeltaBulletPosition()
        {
            return _CurrentMoveAmount;
        }
        #endregion
        #endregion
    }
}
