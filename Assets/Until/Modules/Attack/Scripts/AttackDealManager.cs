using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;


namespace until.modules.attack
{
    public class AttackDealManager : Singleton<AttackDealManager>
    {
        #region Fields
        private List<AttackDealElement> _ElementCollection = new List<AttackDealElement>();
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
        }
        #endregion


        #region Request
        public void request(AttackDealElement element)
        {
            _ElementCollection.Add(element);
        }
        #endregion

        #region Processing
        public void resolve()
        {
            foreach (var element in _ElementCollection)
            {
                element.deal();
            }
            _ElementCollection.Clear();
        }
        #endregion
        #endregion
    }
}


