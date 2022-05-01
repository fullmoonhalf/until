using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using until.system;


namespace until.test
{
    public class AppAstralWorldDatabase : Singleton<AppAstralWorldDatabase>
    {
        private Dictionary<AppStageIdentifier, AppAstralLevelDatabase> _LevelCollection = new Dictionary<AppStageIdentifier, AppAstralLevelDatabase>();


        #region Methods
        #region Singleton
        public override void onSingletonAwake()
        {
        }

        public override void onSingletonStart()
        {
        }

        public override void onSingletonDestroy()
        {
            _LevelCollection.Clear();
        }
        #endregion

        #region Management
        public AppAstralLevelDatabase getLevelDatabase(AppStageIdentifier stage)
        {
            if(_LevelCollection.TryGetValue(stage, out var db))
            {
                return db;
            }

            db = new AppAstralLevelDatabase();
            db.Stage = new AppStageIdentifier(stage);
            _LevelCollection.Add(db.Stage, db);
            return db;
        }
        #endregion

        #endregion
    }
}
