using System.Collections;
using System.Collections.Generic;
using UnityEngine;





namespace until.modules.astral
{
    public class AstralManagerBehavior : MonoBehaviour
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

