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
            var forward = RefPlayer.Position - Singleton.CameraManager.Position;
            forward.y = 0.0f;
            var right = new Vector3(forward.z, 0.0f, -forward.x);
            var stickL = Singleton.InputManager.getStick(InputPad.Player1, InputStickType.L);
            var direction = right * stickL.X + forward * stickL.Y;
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
