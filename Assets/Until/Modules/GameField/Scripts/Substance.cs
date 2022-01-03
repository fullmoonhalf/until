using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;
using until.modules.gamemaster;
using until.utils;


namespace until.modules.gamefield
{
    [DefaultExecutionOrder(until.system.settings.UntilBehaviorOrder.GameField_Substance)]
    public abstract class Substance : Behavior
    {
        #region Definition
        public abstract Vector3 Position { get; set; }
        protected abstract void onWarp(Vector3 position);
        #endregion

        #region Inspector
        [SerializeField]
        private GameEntityIdentifiable _Classification = GameEntityIdentifiable.Invalid;
        [SerializeField]
        private GameEntityIdentifier _Individual = null;
        #endregion

        #region Fields
        public GameEntityIdentifiable ClassificationIdentifier => _Classification;
        public GameEntityIdentifier IndividualIdentifier => _Individual;
        #endregion

        #region Methods
        public void setIndividualIdentifier(GameEntityIdentifier individual)
        {
            _Individual = individual;
        }

        public void warp(Vector3 position)
        {
            onWarp(position);
            Position = position;
        }
        #endregion
    }
}


