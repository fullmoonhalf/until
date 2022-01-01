using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;




namespace until.modules.astral
{
    [DefaultExecutionOrder(until.system.settings.UntilBehaviorOrder.Astral_AstralManagerBehavior)]
    public class AstralManagerBehavior : Behavior
    {
        // Start is called before the first frame update
        void Start()
        {
            Singleton.AstralOrganizationManager.onStart();
            Singleton.AstralManager.onStart();
        }

        // Update is called once per frame
        void Update()
        {
            var delta_time = Time.deltaTime;
            Singleton.AstralOrganizationManager.onUpdate(delta_time);
            Singleton.AstralManager.onUpdate(delta_time);
        }

        void OnDestroy()
        {
            Singleton.AstralManager.onDestroy();
            Singleton.AstralOrganizationManager.onDestroy();
        }
    }
}

