using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using until.system;


namespace until.modules.astral
{
    public class AstralOrganizationManager : Singleton<AstralOrganizationManager>
    {
        #region Fields
        private List<AstralOrganizationGroup> _GroupCollection = new List<AstralOrganizationGroup>();
        #endregion

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
            _GroupCollection.Clear();
        }
        #endregion

        #region Behavior
        public void onStart()
        {
        }

        public void onUpdate(float delta_time)
        {
        }

        public void onDestroy()
        {
        }
        #endregion

        #region Management
        public void regist(AstralOrganizationGroup group)
        {
            _GroupCollection.Add(group);
        }

        public void unregist(AstralOrganizationGroup group)
        {
            _GroupCollection.Remove(group);
        }
        #endregion
        #endregion
    }
}
