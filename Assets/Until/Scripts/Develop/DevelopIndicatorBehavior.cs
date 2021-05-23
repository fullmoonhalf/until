#if TEST
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system.defines;


namespace until.develop
{
    [DefaultExecutionOrder(ExecutionOrder.Develop_Tail_10)]
    public class DevelopIndicatorBehavior : MonoBehaviour
    {
        private void Update()
        {
            singleton.DevelopIndicator.Instance.update();
        }

        // デバッグ描画
        private void OnGUI()
        {
            singleton.DevelopIndicator.Instance.draw(new RectInt(0, 0, Screen.width, Screen.height));
        }
    }
}
#endif
