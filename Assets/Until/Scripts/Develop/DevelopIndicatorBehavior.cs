using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system.defines;


namespace until.develop
{
    [DefaultExecutionOrder(ExecutionOrder.Develop_Tail_10)]
    public class DevelopIndicatorBehavior : MonoBehaviour
    {
        // �f�o�b�O�`��
        private void OnGUI()
        {
            singleton.DevelopIndicator.Instance.draw(new RectInt(0, 0, Screen.width, Screen.height));
        }
    }
}