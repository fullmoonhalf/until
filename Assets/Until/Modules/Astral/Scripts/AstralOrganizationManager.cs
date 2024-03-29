﻿#if false
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
        private Dictionary<AstralOrganizationGroupable, AstralElementable> _GroupCollection = new Dictionary<AstralOrganizationGroupable, AstralElementable>();
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
            foreach (var element in _GroupCollection.Values)
            {
                element.onAstralUpdate(delta_time);
            }
        }

        public void onDestroy()
        {
        }
        #endregion

        #region Management
        public void regist(AstralOrganizationGroupable group)
        {
            var element = new AstralElement(group, group);
            _GroupCollection.Add(group, element);
            group.bind(element);
        }

        public void unregist(AstralOrganizationGroupable group)
        {
            _GroupCollection.Remove(group);
        }
        #endregion
        #endregion
    }
}
#endif
