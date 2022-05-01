using UnityEngine;
using until.develop;
using until.modules.astral;
using until.modules.bullet;
using until.modules.bullet.command;
using until.modules.gamefield;
using until.utils;


namespace until.test
{
    public class AppAstralActionNpcAttack : AppAstralActionNpcBase
    {
        #region Fields
        private int _PhaseCount = 0;
        private float _Timer = 0.0f;
        private Substance _Target;
        #endregion

        #region Methods
        public AppAstralActionNpcAttack(AppSubstanceCharacter substance, Substance target)
             : base(substance)
        {
            _Target = target;
        }

        #region AstralAction
        public override void onAstralActionStart()
        {
            _PhaseCount = 0;
        }

        public override bool onAstralNpcActionUpdate(float delta_time)
        {
            switch (_PhaseCount)
            {
                case 0:
                    _Timer += delta_time;
                    if (_Timer > 1.0f)
                    {
                        _Timer = 0.0f;
                        _PhaseCount++;
                    }
                    break;
                case 1:
                    shot();
                    _PhaseCount++;
                    break;
                case 2:
                    _Timer += delta_time;
                    if (_Timer > 0.5f)
                    {
                        _Timer = 0.0f;
                        _PhaseCount++;
                    }
                    break;
                default:
                    return false;
            }

            return true;
        }

        private void shot()
        {
            var forward = _Target.Position - RefSubstance.Position;
            forward.y = 0.0f;
            forward = forward.normalized;
            var specifier = new BulletEmitSpecifier();
            specifier.Commands = new BulletEmitCommand[] {
                new BulletEmitCommandSystemSetParameter(new AppBulletParameter(RefSubstance)),
                new BulletEmitCommandEmitSetTransform(RefSubstance.Position+forward*0.5f+Vector3.up*0.5f, Quaternion.identity),
                new BulletEmitCommandBulletEmitRelativeUniformLinearMotion("Bullet0002", forward * 10.0f, 3.0f),
                new BulletEmitCommandControlSleep(0.1f),
                new BulletEmitCommandControlRepeat(3, 2),
            };
            Singleton.BulletManager.regist(new BulletEmitter(specifier));
        }

        public override void onAstralActionEnd()
        {
        }

        public override AstralInterceptResult onAstralInterceptTry(AstralInterfereable interferer)
        {
            return AstralInterceptResult.Cancel_Through;
        }

        public override void onAstralInterceptEstablished(AstralInterfereable interferer)
        {
        }
        #endregion
        #endregion
    }
}
