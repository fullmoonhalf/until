﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.system;


namespace until.modules.gamefield
{
    [DefaultExecutionOrder(until.system.settings.UntilBehaviorOrder.GameField_IngameFieldBehavior)]
    public class IngameFieldBehavior : Behavior
    {
        private void Start()
        {
            Singleton.IngameField.onStart();
            Singleton.SubstanceManager.onStart();
            Singleton.StageSetupper.onStart();
            Singleton.StageSceneManager.onStart();
        }

        private void Update()
        {
            Singleton.StageSetupper.onUpdate();
            Singleton.SubstanceManager.onUpdate();
            Singleton.IngameField.onUpdate();
            Singleton.StageSceneManager.onUpdate();
        }

        private void OnDestroy()
        {
            Singleton.StageSceneManager.onDestroy();
            Singleton.StageSetupper.onDestroy();
            Singleton.SubstanceManager.onDestroy();
            Singleton.IngameField.onDestroy();
        }
    }
}
