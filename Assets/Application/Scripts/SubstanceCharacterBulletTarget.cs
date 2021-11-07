using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.modules.bullet;


namespace until.test
{
    public class SubstanceCharacterBulletTarget : BulletTarget
    {
        #region Serialized.
        [SerializeField]
        private SubstanceCharacter _RefCharacter = null;
        #endregion

        #region Methods
        #region BulletTarget
        public override void onContactBullet(BulletClient bullet)
        {
            bullet.requestToFinish();
        }
        #endregion
        #endregion
    }
}
