using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using until.system;


namespace until.test
{
    public class AppAstralLevelDatabase
    {
        public AppStageIdentifier Stage { get; set; } = null;
        public AppNavigationWaypointsCollection Waypoints { get; set; } = null;

        public AppAstralLevelDatabase()
        {
        }
    }
}
