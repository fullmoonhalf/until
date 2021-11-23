using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;



namespace until.modules.bullet
{
    public class BulletAnimatorUniformLinearMotion : BulletAnimator
    {
        #region Fields
        private Vector3 _Speed = Vector3.zero;
        private Vector3 _CurrentMoveAmount = Vector3.zero;
        private float _Life = float.MaxValue;
        private float _Age = 0.0f;
        #endregion

        #region Methods
        #region Constructor
        public BulletAnimatorUniformLinearMotion(Vector3 speed, float life)
        {
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
            _CurrentMoveAmount = _Speed * elapsed;
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
