using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using until.modules.astral;



namespace until.test
{
    public abstract class AppAstralActionNpcBase : AstralAction
    {
        #region Fields
        protected AppSubstanceCharacter RefSubstance { get; private set; } = null;
        private AppAstralActionNpcCogitation RefCogitation = null;
        #endregion

        #region Methods
        public AppAstralActionNpcBase(AppSubstanceCharacter substance, AppAstralActionNpcCogitation cogitation)
        {
            RefSubstance = substance;
            RefCogitation = cogitation;
        }

        #region AstralAction
        public AstralAction getNextAstralAction()
        {
            return RefCogitation;
        }

        public abstract void onAstralActionStart();
        public abstract bool onAstralActionUpdate(float delta_time);
        public abstract void onAstralActionEnd();
        #endregion
        #endregion
    }
}
