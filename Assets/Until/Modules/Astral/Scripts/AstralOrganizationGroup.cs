using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.system;


namespace until.modules.astral
{
    public abstract class AstralOrganizationGroup : AstralAction
    {
        #region Properties
        public AstralElement Element { get; private set; }
        #endregion

        #region Methods
        public void bind(AstralElement element)
        {
            Element = element;
        }

        #region AstralAction
        public abstract void onAstralActionEnd();
        public abstract bool onAstralActionUpdate(float delta_time);
        public abstract void onAstralActionStart();
        public abstract AstralAction getNextAstralAction();
        public abstract AstralInterceptResult onAstralInterceptTry(AstralInterfereable interferer);
        public abstract void onAstralInterceptEstablished(AstralInterfereable interferer);
        public abstract void onAstralWarp(Vector3 position);
        #endregion
        #endregion
    }
}
