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
        private BulletClient _Bullet = null;
        #endregion

        #region Metho\ds
        public AppAstralInterfererBullet(BulletClient bullet)
        {
            _Bullet = bullet;
        }

        #region AstralInterfereable
        public void onAcceptInterference()
        {
            _Bullet.requestToFinish();
        }
        #endregion

        #endregion


    }
}
