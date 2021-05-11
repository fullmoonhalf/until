using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace until.system
{
    public class BootSystemBehavior : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            singleton.BootSystem.Instance.onUpdate();
        }
    }
}

