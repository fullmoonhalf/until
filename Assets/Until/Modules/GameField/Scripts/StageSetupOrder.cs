using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.develop;


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
    public class StageSetupOrder
    {
        public StageSetupStageOrder[] StageOrder = null;
    }

    public class StageSetupOrderBuilder
    {
        private List<StageSetupStageOrder> _StageOrderList = new List<StageSetupStageOrder>();

        public StageSetupOrderBuilder()
        {
        }

        public void add(StageIdentifier stage, StageSceneStatus target)
        {
            _StageOrderList.Add(new StageSetupStageOrder(stage, target));
        }

        public StageSetupOrder build()
        {
            var order = new StageSetupOrder();
            order.StageOrder = _StageOrderList.ToArray();
            return order;
        }
    }
}