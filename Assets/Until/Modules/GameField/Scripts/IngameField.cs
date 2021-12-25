using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.system;


namespace until.modules.gamefield
{
    public class IngameField : Singleton<IngameField>
    {
        #region Definitions
        public enum Phase
        {
            Initial,
        }
        #endregion

        #region Fields.
        private Phase _CurrentPhase = Phase.Initial;
        #endregion

        #region Singleton
        public override void onSingletonAwake()
        {
        }

        public override void onSingletonStart()
        {
        }

        public override void onSingletonDestroy()
        {
        }
        #endregion

        #region Methods
        #region Behavior
        public void onStart()
        {
        }

        public void onUpdate()
        {
            switch (_CurrentPhase)
            {
                case Phase.Initial:
                    break;
            }
        }

        public void onDestroy()
        {
        }
        #endregion

        #region Process Control
        #endregion

        #region Request
        public void requestToStart()
        {
        }

        public void requestToEnd()
        {
        }
        #endregion
        #endregion
    }
}
