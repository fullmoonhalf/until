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
        protected AppAstralActionNpcCogitation RefCogitation { get; private set; } = null;
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

        public bool onAstralInterceptTry(AstralInterfereable interferer)
        {
            return RefCogitation.onAstralInterceptTry(interferer);
        }

        public bool onAstralActionUpdate(float delta_time)
        {
            return onAstralNpcActionUpdate(delta_time);
        }

        public abstract void onAstralActionStart();
        public abstract bool onAstralNpcActionUpdate(float delta_time);
        public abstract void onAstralActionEnd();
        public abstract void onAstralInterceptEstablished(AstralInterfereable interferer);
        #endregion
        #endregion
    }
}
