using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.system
{
    [DefaultExecutionOrder(defines.ExecutionOrder.GameObjectManagementBehavior)]
    public class GameObjectManagementBehavior : MonoBehaviour
    {
        void Update()
        {
            singleton.SceneLoader.Instance.onUpdate();
            singleton.PrefabInstantiateMediator.Instance.onUpdate();
            singleton.GameObjectControlMediator.Instance.onUpdate();
        }
    }
}

