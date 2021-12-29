using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;
using until.modules.gamemaster;
using until.utils;


namespace until.modules.gamefield
{
    [DefaultExecutionOrder(system.defines.ExecutionOrder.Undefined)]
    public abstract class Substance : Behavior
    {
        #region Definition
        public abstract Vector3 Position { get; set; }
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
        #endregion
    }
}


