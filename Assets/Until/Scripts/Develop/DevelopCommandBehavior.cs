using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;
using until.system.defines;


namespace until.develop
{
    [DefaultExecutionOrder(ExecutionOrder.Develop_Tail_10)]
    public class DevelopCommandBehavior : Behavior
    {
        // Update is called once per frame
        private void Update()
        {
            Singleton.DevelopCommandManager.update();
        }

        private void OnGUI()
        {
            var screen = new Rect(200, 100, 400, 150);
            Singleton.DevelopCommandManager.draw(screen);
        }
    }
}


