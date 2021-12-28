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
            {
                var forward = RefPlayer.Position - Singleton.CameraManager.Position;
                forward.y = 0.0f;
                forward.Normalize();
                var specifier = new BulletEmitSpecifier();
                specifier.Commands = new BulletEmitCommand[] {
                    new BulletEmitCommandEmitSetTransform(RefPlayer.Position+forward, Quaternion.identity),
                    new BulletEmitCommandBulletEmitRelativeUniformLinearMotion("Bullet0001", forward * 10.0f, 3.0f),
                    new BulletEmitCommandControlSleep(0.1f),
                    new BulletEmitCommandControlRepeat(3, 1),
                };
                Singleton.BulletManager.regist(new BulletEmitter(specifier));
            }
#if false
            {
                var specifier = new BulletEmitSpecifier();
                specifier.Commands = new BulletEmitCommand[] {
                    new BulletEmitCommandEmitSetTransform(new Vector3(2.0f, 0.0f, -2.0f), Quaternion.identity),
                    new BulletEmitCommandBulletEmitRelativeUniformLinearMotion("Bullet0001", Vector3.right, 10.0f),
                    new BulletEmitCommandEmitRotate(Quaternion.Euler(0.0f, -60.0f, 0.0f), 0.1f),
                    new BulletEmitCommandControlRepeat(15, 1),
                };
                Singleton.BulletManager.regist(new BulletEmitter(specifier));
            }

            {
                var specifier = new BulletEmitSpecifier();
                specifier.Commands = new BulletEmitCommand[] {
                    new BulletEmitCommandEmitSetTransform(new Vector3(-3.0f, 0.0f, 1.0f), Quaternion.identity),
                    new BulletEmitCommandBulletEmitRelativeUniformLinearMotion("Bullet0001", Vector3.right, 10.0f),
                    new BulletEmitCommandEmitTranslate(Vector3.forward*0.3f, 0.2f),
                    new BulletEmitCommandBulletEmitRelativeUniformLinearMotion("Bullet0001", Vector3.right, 10.0f),
                    new BulletEmitCommandControlSleep(0.1f),
                    new BulletEmitCommandControlRepeat(10, 1),
                };
                Singleton.BulletManager.regist(new BulletEmitter(specifier));
            }

            {
                var specifier = new BulletEmitSpecifier();
                specifier.Commands = new BulletEmitCommand[] {
                    new BulletEmitCommandEmitSetTransform(new Vector3(3.0f, 0.0f, -1.0f), Quaternion.identity),
                    new BulletEmitCommandBulletEmitRelativeUniformLinearMotion("Bullet0001", Vector3.left, 10.0f),
                    new BulletEmitCommandEmitTranslate(Vector3.back*0.3f, 0.2f),
                    new BulletEmitCommandBulletEmitRelativeUniformLinearMotion("Bullet0001", Vector3.left, 10.0f),
                    new BulletEmitCommandControlSleep(0.1f),
                    new BulletEmitCommandControlRepeat(10, 1),
                };
                Singleton.BulletManager.regist(new BulletEmitter(specifier));
            }

            {
                var attribute = GameEntityIdentifiable.until_test_CharacterID_Ch01000.getAttrubute<GameEntityIdentifierValueAttribute>();
                var identifier = attribute.createGameEntityIdentifier();
                var specifier = new BulletEmitSpecifier();
                specifier.Commands = new BulletEmitCommand[] {
                    new BulletEmitCommandEmitSetTransform(new Vector3(2.0f, 0.0f, 2.0f), Quaternion.identity),
                    new BulletEmitCommandBulletEmitRelativeHomingMotion("Bullet0001", identifier.Expression, 1.0f, 10.0f ),
                };
                Singleton.BulletManager.regist(new BulletEmitter(specifier));
            }
            {
                var attribute = GameEntityIdentifiable.until_test_CharacterID_Ch01000.getAttrubute<GameEntityIdentifierValueAttribute>();
                var identifier = attribute.createGameEntityIdentifier();
                var specifier = new BulletEmitSpecifier();
                specifier.Commands = new BulletEmitCommand[] {
                    new BulletEmitCommandEmitSetTransform(new Vector3(-2.0f, 0.0f, -2.0f), Quaternion.identity),
                    new BulletEmitCommandBulletEmitRelativeHomingMotion("Bullet0001", identifier.Expression, 1.0f, 10.0f ),
                };
                Singleton.BulletManager.regist(new BulletEmitter(specifier));
            }
#endif
        }
        #endregion
    }
}
