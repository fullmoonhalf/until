using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.test3
{
    public class DeltaSituation
    {
        /// <summary>�o�ߎ�����</summary>
        public float DeltaTime { get; private set; }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="delta_time"></param>
        public DeltaSituation(float delta_time)
        {
            DeltaTime = delta_time;
        }
    }
}

