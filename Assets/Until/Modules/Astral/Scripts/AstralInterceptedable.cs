using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace until.modules.astral
{
    /// <summary>
    /// 妨害される側
    /// </summary>
    public interface AstralInterceptedable
    {
        public bool onAstralInterceptTry(AstralInterfereable interferer);
        public void onAstralInterceptEstablished(AstralInterfereable interferer);
    }
}
