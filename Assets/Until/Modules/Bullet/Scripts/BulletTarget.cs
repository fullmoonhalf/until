using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using until.system;


namespace until.modules.bullet
{
    public abstract class BulletTarget : Behavior
    {
        public abstract void onContactBullet(BulletClient bullet);
    }
}
