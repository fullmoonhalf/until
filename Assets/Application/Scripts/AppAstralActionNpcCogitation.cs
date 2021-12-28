using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using until.modules.astral;
using until.utils;


namespace until.test
{
    public class AppAstralActionNpcCogitation : AstralAction
    {
        #region Fields
        protected AppSubstanceCharacter RefSubstance { get; private set; } = null;
        #endregion

        #region Methods
        public AppAstralActionNpcCogitation(AppSubstanceCharacter substance)
        {
            RefSubstance = substance;
        }

        #region AstralAction
        public AstralAction getNextAstralAction()
        {
            var x = math.getRandomRange(-3.0f, 3.0f);
            var z = math.getRandomRange(-3.0f, 3.0f);
            var pos = new Vector3(x, 0.0f, z);
            var db = Singleton.AppAstralWorldDatabase.getLevelDatabase(new AppStageIdentifier(LevelID.lv_003_001_00));
            if(db != null && db.Waypoints != null && db.Waypoints.Waypoints.Length > 0)
            {
                var index = math.getRandomIndex(db.Waypoints.Waypoints.Length);
                pos += db.Waypoints.Waypoints[index].Position;
            }

            var action = new AppAstralActionNpcMove(RefSubstance, this, pos);
            return action;
        }

        public void onAstralActionStart()
        {
        }
        public bool onAstralActionUpdate(float delta_time)
        {
            return false;
        }
        public void onAstralActionEnd()
        {
        }
        #endregion
        #endregion
    }
}
