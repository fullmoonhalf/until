using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.test3
{
    public class DeltaSituation
    {
        /// <summary>経過実時間</summary>
        public float DeltaTime { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="delta_time"></param>
        public DeltaSituation(float delta_time)
        {
            DeltaTime = delta_time;
        }
    }
}

