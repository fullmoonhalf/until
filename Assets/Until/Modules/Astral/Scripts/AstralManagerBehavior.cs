using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;




namespace until.modules.astral
{
    public class AstralManagerBehavior : Behavior
    {
        // Start is called before the first frame update
        void Start()
        {
            Singleton.AstralManager.onStart();
        }

        // Update is called once per frame
        void Update()
        {
            Singleton.AstralManager.onUpdate(Time.deltaTime);
        }

        void OnDestroy()
        {
            Singleton.AstralManager.onDestroy();
        }
    }
}

