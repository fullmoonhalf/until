using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.bullet.command
{
    [Serializable]
    public class BulletEmitFixedLinerCommand : BulletEmitCommand
    {
        #region Parameters
        public string BulletName = "";
        public Vector3 StartPosition = Vector3.zero;
        public Vector3 Speed = Vector3.zero;
        public float Life = float.MaxValue;
        #endregion

        #region Constructor
        public BulletEmitFixedLinerCommand(string name, Vector3 start, Vector3 speed, float life)
        {
            BulletName = name;
            StartPosition = start;
            Speed = speed;
            Life = life;
        }
        #endregion


        #region BulletEmitCommand
        public BulletEmidCommandMnemonic Mnemonic => BulletEmidCommandMnemonic.FixedLiner;

        public BulletEmitCommandContext createContext()
        {
            return new Context(this);
        }
        #endregion

        #region Context
        private class Context : BulletEmitCommandContext
        {
            private BulletEmitFixedLinerCommand _Command = null;

            public Context(BulletEmitFixedLinerCommand command)
            {
                _Command = command;
            }

            public bool execute(float elapsed)
            {
                var bullet = Singleton.BulletManager.rent(_Command.BulletName);
                if (bullet == null)
                {
                    return true;
                }

                var animator = new Animator(_Command.Speed, _Command.Life);
                bullet.startBullet(animator, _Command.StartPosition);
                return true;
            }
        }
        #endregion

        #region Animator
        private class Animator : BulletAnimator
        {
            #region Fields
            private Vector3 _Speed = Vector3.zero;
            private Vector3 _CurrentMoveAmount = Vector3.zero;
            private float _Life = float.MaxValue;
            private float _Age = 0.0f;
            #endregion

            #region Methods
            #region Constructor
            public Animator(Vector3 speed, float life)
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
        #endregion
    }
}


