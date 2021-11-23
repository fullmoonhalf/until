#if TEST
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.develop;
using until.system;
using until.modules.bullet;
using until.modules.bullet.command;

namespace until.test
{
    public class AppmodeIngame : Mode
    {
        private float _Age = 0.0f;

        public Mode.Control init()
        {
            TestLog.test(this, "init");
            _Age = 3.0f;
            return Mode.Control.Done;
        }

        public Mode.Control update()
        {
            Singleton.AstralAdministrator.updateAstral();

            if (_Age >= 3.0f)
            {
                {
                    var specifier = new BulletEmitSpecifier();
                    specifier.Commands = new BulletEmitCommand[] {
                        new BulletEmitCommandEmitSetTransform(new Vector3(0.0f, 0.0f, 1.0f), Quaternion.identity),
                        new BulletEmitCommandBulletAbsoluteUniformLinearMotion("Bullet0001", new Vector3(0.0f, 0.0f, 2.0f), Vector3.right, 10.0f),
                        new BulletEmitCommandBulletEmitRelativeUniformLinearMotion("Bullet0001", Vector3.right, 10.0f),
                        new BulletEmitCommandEmitRotate(Quaternion.Euler(0.0f, 60.0f, 0.0f), 0.1f),
                        new BulletEmitCommandControlRepeat(10, 1),
                    };
                    Singleton.BulletManager.regist(new BulletEmitter(specifier));
                }
                {
                    var specifier = new BulletEmitSpecifier();
                    specifier.Commands = new BulletEmitCommand[] {
                        new BulletEmitCommandEmitSetTransform(new Vector3(0.0f, 0.0f, 1.0f), Quaternion.identity),
                        new BulletEmitCommandBulletEmitRelativeUniformLinearMotion("Bullet0001", Vector3.right, 10.0f),
                        new BulletEmitCommandEmitTranslate(Vector3.forward*0.3f, 0.2f),
                        new BulletEmitCommandBulletEmitRelativeUniformLinearMotion("Bullet0001", Vector3.right, 10.0f),
                        new BulletEmitCommandControlSleep(0.1f),
                        new BulletEmitCommandControlRepeat(10, 1),
                    };
                    Singleton.BulletManager.regist(new BulletEmitter(specifier));
                }
                _Age -= 3.0f;
            }

            _Age += Time.deltaTime;
            return Mode.Control.Keep;
        }

        public Mode.Control exit()
        {
            TestLog.test(this, "exit");
            return Mode.Control.Done;
        }
    }
}
#endif
