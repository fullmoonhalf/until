using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using until.modules.astral;
using until.modules.bullet;


namespace until.test
{
    public class AppAstralInterfererBullet : AstralInterfereable
    {
        #region Fields
        public BulletClient Bullet { get; private set; } = null;
        #endregion

        #region Metho\ds
        public AppAstralInterfererBullet(BulletClient bullet)
        {
            Bullet = bullet;
        }

        #region AstralInterfereable
        public void onAcceptInterference()
        {
            Bullet.requestToFinish();
        }

        public void onRejectInterference()
        {
            Bullet.requestToFinish();
        }
        #endregion
        #endregion


    }
}
