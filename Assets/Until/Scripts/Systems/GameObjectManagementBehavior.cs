using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.system
{
    [DefaultExecutionOrder(defines.ExecutionOrder.System_Head_10)]
    public class GameObjectManagementBehavior : MonoBehaviour
    {
        void Update()
        {
            Singleton.SceneLoader.onUpdate();
            Singleton.PrefabInstantiateMediator.onUpdate();
            Singleton.GameObjectControlMediator.onUpdate();
        }
    }
}

