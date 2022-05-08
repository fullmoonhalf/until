using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using until.modules.astral;

namespace until.test
{
    public abstract class AppAstralSpriteBase : AstralSpritable<AppAstralSpriteBase>
    {
        public AppAstralSpriteBase()
        {
        }
    }

    public abstract class AppAstralActionBase : AstralActionable<AppAstralActionBase, AppAstralSpriteBase>
    {
        public AppAstralActionBase()
        {
        }
    }

    public class AppAstralElement : AstralElement<AppAstralActionBase, AppAstralSpriteBase>
    {
        public AppAstralElement(AppAstralActionBase start_action, AppAstralSpriteBase sprite)
            : base(start_action, sprite)
        {
        }

        public AppAstralElement(AppAstralActionBase start_action, AstralInterceptedable receiver)
            : base(start_action, receiver)
        {

        }
    }
}
