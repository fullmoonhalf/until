using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.modules.astral;



namespace until.test
{
    public class AppAstralActionNpcMove : AppAstralActionNpcBase
    {
        #region Fields
        private Vector3 _TargetPosition = Vector3.zero;
        #endregion

        #region Methods
        public AppAstralActionNpcMove(AppSubstanceCharacter substance, AppAstralActionNpcCogitation cogitation, Vector3 target)
             : base(substance, cogitation)
        {
            _TargetPosition = target;
        }

        #region AstralAction
        public override void onAstralActionStart()
        {
        }
        public override bool onAstralActionUpdate(float delta_time)
        {
            var gap = _TargetPosition - RefSubstance.Position;
            var speed = 3.0f * delta_time;
            var distance = gap.magnitude;
            if (speed >= distance)
            {
                RefSubstance.Position = _TargetPosition;
                return false;
            }

            var direction = gap.normalized;
            RefSubstance.Position += direction * speed;
            return true;
        }
        public override void onAstralActionEnd()
        {
        }
        #endregion
        #endregion
    }
}
