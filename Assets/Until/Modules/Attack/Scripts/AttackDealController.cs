using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;


namespace until.modules.attack
{
    [DefaultExecutionOrder(system.defines.ExecutionOrder.Develop_Tail_20)]
    public class AttackDealController : Behavior
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Singleton.AttackDealManager.resolve();
        }
    }
}

