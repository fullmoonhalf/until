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
    public class IngameMode : Mode
    {
        private int _FrameCount = 0;

        public Mode.Control init()
        {
            TestLog.test(this, "init");
            _FrameCount = 0;
            return Mode.Control.Done;
        }

        public Mode.Control update()
        {
            if (_FrameCount == 0)
            {
                TestLog.test(this, "update");
            }

            Singleton.AstralAdministrator.updateAstral();

            if (_FrameCount % 100 == 0)
            {
                var specifier = new BulletEmitSpecifier();
                specifier.Commands = new BulletEmitCommand[1] {
                    new BulletEmitFixedLinerCommand("Bullet0001", new Vector3(0.0f, 0.0f, 2.0f), Vector3.right, 10.0f),
                };
                var emiiter = new BulletEmitter(specifier);
                emiiter.onUpdate(0.0f);
            }

            ++_FrameCount;
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
