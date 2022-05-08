using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace until.modules.astral
{
    public abstract class AstralSpritable<TypeAstralSprite> : AstralInterceptedable
        where TypeAstralSprite : AstralSpritable<TypeAstralSprite>
    {
        public abstract void onAstralInterceptEstablished(AstralInterfereable interferer);
        public abstract AstralInterceptResult onAstralInterceptTry(AstralInterfereable interferer);
    }
}
