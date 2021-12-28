using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.modules.bullet;
using until.modules.gamemaster;
using until.utils;

namespace until.test
{
    public class AppSubstanceCharacterBulletTarget : BulletTarget
    {
        #region Serialized.
        [SerializeField]
        private AppSubstanceCharacter _RefCharacter = null;
        #endregion

        #region Methods
        #region BulletTarget
        public override Vector3 BulletTargetPosotion => _RefCharacter.transform.position;
        public override string BulletTargetIdentifier => _RefCharacter.GameIdentifier.Expression;

        public override void onContactBullet(BulletClient bullet)
        {
            if (_RefCharacter != null)
            {
                _RefCharacter.interfere(new AppAstralInterfererBullet(bullet));
            }
        }
        #endregion
        #endregion
    }
}
