using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using until.modules.astral;



namespace until.test
{
    public abstract class AppAstralActionPlayerBase : AstralAction
    {
        #region Fields
        protected AppSubstancePlayer RefPlayer { get; private set; } = null;
        #endregion

        #region Methods
        public AppAstralActionPlayerBase(AppSubstancePlayer player)
        {
            RefPlayer = player;
        }

        #region AstralAction
        public AstralAction getNextAstralAction()
        {
            return new AppAstralActionPlayerControl(RefPlayer);
        }

        public abstract void onAstralActionStart();
        public abstract bool onAstralActionUpdate(float delta_time);
        public abstract void onAstralActionEnd();
        #endregion
        #endregion
    }
}
