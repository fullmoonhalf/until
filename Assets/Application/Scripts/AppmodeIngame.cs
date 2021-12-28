#if TEST
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.develop;
using until.system;
using until.modules.bullet;
using until.modules.bullet.command;
using until.modules.gamemaster;
using until.utils;


namespace until.test
{
    public class AppmodeIngame : Mode
    {
        public Mode.Control init()
        {
            return Mode.Control.Done;
        }

        public Mode.Control update()
        {
            return Mode.Control.Keep;
        }

        public Mode.Control exit()
        {
            return Mode.Control.Done;
        }
    }
}
#endif
