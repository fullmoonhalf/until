using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace until.modules.astral
{
    /// <summary>
    /// 妨害する側
    /// </summary>
    public interface AstralInterfereable
    {
        public void onAcceptInterference();
        public void onRejectInterference();
    }
}
