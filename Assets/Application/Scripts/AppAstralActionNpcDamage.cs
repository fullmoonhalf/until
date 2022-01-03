using UnityEngine;
using until.develop;
using until.modules.astral;
using until.utils;


namespace until.test
{
    public class AppAstralActionNpcDamage : AppAstralActionNpcBase
    {
        #region Fields
        private float _Timer = 0.0f;
        #endregion

        #region Methods
        public AppAstralActionNpcDamage(AppSubstanceCharacter substance)
             : base(substance)
        {
        }

        #region AstralAction
        public override void onAstralActionStart()
        {
            Log.info(this, nameof(onAstralActionStart));
        }
        public override bool onAstralNpcActionUpdate(float delta_time)
        {
            _Timer += delta_time;
            return _Timer < 1.0f;
        }

        public override void onAstralActionEnd()
        {
            Log.info(this, nameof(onAstralActionEnd));
        }

        public override AstralInterceptResult onAstralInterceptTry(AstralInterfereable interferer)
        {
            return AstralInterceptResult.Cancel_Through;
        }

        public override void onAstralInterceptEstablished(AstralInterfereable interferer)
        {
        }
        #endregion
        #endregion
    }
}
