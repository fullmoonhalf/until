using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using until.modules.bullet;
using until.modules.gamefield;


namespace until.test
{
    public class AppBulletParameter : BulletParameter
    {
        public Substance Owner { get; private set; } = null;

        public AppBulletParameter(Substance owner)
        {
            Owner = owner;
        }
    }
}
