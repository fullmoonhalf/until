using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.develop;
using until.modules.gamemaster;

namespace until.modules.gamefield
{
    [Serializable]
    public class StageSetupStageOrder
    {
        public StageIdentifier Stage = null;
        public StageSceneStatus Target = StageSceneStatus.Unload;

        public StageSetupStageOrder()
        {
        }
        public StageSetupStageOrder(StageIdentifier stage, StageSceneStatus target)
        {
            Stage = stage;
            Target = target;
        }
    }

    [Serializable]
    public class StageSetupSubstanceOrder
    {
        public GameEntityIdentifiable ClassificationIdentifier = GameEntityIdentifiable.Invalid;
        public GameEntityIdentifier IndividualIdentifier = null;
        public Vector3 Position = Vector3.zero;

        public StageSetupSubstanceOrder()
        {
        }
        public StageSetupSubstanceOrder(GameEntityIdentifiable classification, GameEntityIdentifier individual, Vector3 position)
        {
            ClassificationIdentifier = classification;
            IndividualIdentifier = individual;
            Position = position;
        }
    }

    [Serializable]
    public class StageSetupOrder
    {
        public StageSetupStageOrder[] StageOrders = null;
        public StageSetupSubstanceOrder[] SubstanceOrders = null;
    }

    public class StageSetupOrderBuilder
    {
        private List<StageSetupStageOrder> _StageOrderList = new List<StageSetupStageOrder>();
        private List<StageSetupSubstanceOrder> _SubstanceOrderList = new List<StageSetupSubstanceOrder>();

        public StageSetupOrderBuilder()
        {
        }

        public void add(StageIdentifier stage, StageSceneStatus target)
        {
            _StageOrderList.Add(new StageSetupStageOrder(stage, target));
        }

        public void add(GameEntityIdentifiable classification, GameEntityIdentifier individual, Vector3 position)
        {
            _SubstanceOrderList.Add(new StageSetupSubstanceOrder(classification, individual, position));
        }

        public StageSetupOrder build()
        {
            var order = new StageSetupOrder();
            order.StageOrders = _StageOrderList.ToArray();
            order.SubstanceOrders = _SubstanceOrderList.ToArray();
            return order;
        }
    }
}