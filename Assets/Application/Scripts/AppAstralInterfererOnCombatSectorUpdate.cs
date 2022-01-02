using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using until.modules.astral;


namespace until.test
{
    public class AppAstralInterfererOnCombatSectorUpdate : AstralInterfereable
    {
        #region Property
        public int SectorID { get; private set; }
        #endregion

        #region Method
        public AppAstralInterfererOnCombatSectorUpdate(int sector)
        {
            SectorID = sector;
        }

        #region AstralInterfereable
        public void onAcceptInterference()
        {
        }

        public void onRejectInterference()
        {
        }
        #endregion
        #endregion
    }
}
