using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.system;
using until.modules.astral;



namespace until.test
{
    public class AppAstralActionPlayerControl : AppAstralActionPlayerBase
    {
        #region Methods
        #region Constractor
        public AppAstralActionPlayerControl(AppSubstancePlayer player)
            : base(player)
        {
        }
        #endregion


        #region AstralAction
        public override void onAstralActionStart()
        {
        }

        public override bool onAstralActionUpdate(float delta_time)
        {
            var stickL = Singleton.InputManager.getStick(InputPad.Player1, InputStickType.L);
            var direction = Vector3.right * stickL.X + Vector3.forward * stickL.Y;
            var speed = 1.0f * delta_time;
            RefPlayer.Position += direction * speed;
            return true;
        }

        public override void onAstralActionEnd()
        {
        }
        #endregion
        #endregion
    }
}
