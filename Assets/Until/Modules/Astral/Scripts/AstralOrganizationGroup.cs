#if false
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.system;


namespace until.modules.astral
{
    public interface AstralOrganizationGroupable
    {
        public void onAstralUpdate(float delta_time);
    }


    public abstract class AstralOrganizationGroup<TypeAstralAction, TypeAstralSprite>
        : AstralActionable<TypeAstralAction, TypeAstralSprite>, AstralOrganizationGroupable
        where TypeAstralAction : AstralActionable<TypeAstralAction, TypeAstralSprite>
        where TypeAstralSprite : AstralSpritable<TypeAstralSprite>
    {
        #region Properties
        public AstralElement<TypeAstralAction, TypeAstralSprite> Element { get; private set; }
        #endregion

        #region Methods
        public void bind(AstralElement<TypeAstralAction, TypeAstralSprite> element)
        {
            Element = element;
        }
        #endregion
    }
}
#endif
