using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.modules.astral;



namespace until.test
{
    public abstract class AppAstralSquadActionBase : AstralAction
    {
        #region Fields
        public AppAstralSquad RefSquad { get; private set; } = null;
        #endregion

        #region Methods
        public AppAstralSquadActionBase(AppAstralSquad squad)
        {
            RefSquad = squad;
        }

        #region AstralAction
        public AstralAction getNextAstralAction()
        {
            return RefSquad.getNextAstralAction();
        }

        public void onAstralWarp(Vector3 position)
        {
        }

        public abstract void onAstralActionStart();
        public abstract bool onAstralActionUpdate(float delta_time);
        public abstract void onAstralActionEnd();
        public abstract bool onAstralInterceptTry(AstralInterfereable interferer);
        public abstract void onAstralInterceptEstablished(AstralInterfereable interferer);
        #endregion

        #region Squad
        public abstract AstralAction getMemberAstralAction(AppSubstanceCharacter substance);
        #endregion
        #endregion
    }
}
