using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.system;
using until.modules.bullet;
using until.modules.bullet.command;
using until.modules.gamemaster;
using until.utils;
using until.modules.astral;

namespace until.test
{
    public class AppAstralActionPlayerControl : AppAstralActionPlayerBase
    {
        #region Methods
        #region Constractor
        public AppAstralActionPlayerControl(AppSubstancePlayer player)
            : base(player)
        {
        }
        #endregion


        #region AstralAction
        public override void onAstralActionStart()
        {
        }

        public override bool onAstralActionUpdate(float delta_time)
        {
            move(delta_time);
            if (Singleton.InputManager.isTrig(InputPad.Player1, InputButton.R2))
            {
                shot();
            }
            return true;
        }

        public override void onAstralActionEnd()
        {
        }

        public override bool onAstralInterceptTry(AstralInterfereable interferer)
        {
            return false;
        }

        public override void onAstralInterceptEstablished(AstralInterfereable interferer)
        {
        }

        public override void onAstralWarp(Vector3 position)
        {
        }
        #endregion


        private void move(float delta_time)
        {
            var forward = RefPlayer.Position - Singleton.CameraManager.Position;
            forward.y = 0.0f;
            var right = new Vector3(forward.z, 0.0f, -forward.x);
            var stickL = Singleton.InputManager.getStick(InputPad.Player1, InputStickType.L);
            var direction = right * stickL.X + forward * stickL.Y;
            var speed = 1.0f * delta_time;
            RefPlayer.Position += direction * speed;
        }

        private void shot()
        {
            var forward = RefPlayer.Position - Singleton.CameraManager.Position;
            forward.y = 0.0f;
            forward = forward.normalized;
            var specifier = new BulletEmitSpecifier();
            specifier.Commands = new BulletEmitCommand[] {
                new BulletEmitCommandSystemSetParameter(new AppBulletParameter(RefPlayer)),
                new BulletEmitCommandEmitSetTransform(RefPlayer.Position+forward*0.5f+Vector3.up*0.5f, Quaternion.identity),
                new BulletEmitCommandBulletEmitRelativeUniformLinearMotion("Bullet0001", forward * 10.0f, 3.0f),
                new BulletEmitCommandControlSleep(0.1f),
                new BulletEmitCommandControlRepeat(3, 2),
            };
            Singleton.BulletManager.regist(new BulletEmitter(specifier));
        }
        #endregion
    }
}
