using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace until.modules.astral
{
    public enum AstralInterceptResult
    {
        Cancel_Through,
        Cancel_ActionEnd,
        Establish,
    }

    /// <summary>
    /// 妨害される側
    /// </summary>
    public interface AstralInterceptedable
    {
        public AstralInterceptResult onAstralInterceptTry(AstralInterfereable interferer);
        public void onAstralInterceptEstablished(AstralInterfereable interferer);
    }
}
