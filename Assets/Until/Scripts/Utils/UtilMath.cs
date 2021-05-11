using UnityEngine;


namespace until.utils
{
    public static class math
    {
        public const float EPSILON = 0.000005f;

        public static bool checkNearlyEqual(float CheckValue, float TestValue, float Epsilon = EPSILON)
        {
            float Differance = Mathf.Abs(CheckValue - TestValue);
            return Differance < Epsilon;
        }

        /// <summary>
        /// 0° ～ 360° の主角に変換する。
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        public static float getDegreeArgument(float degree)
        {
            if(degree < 0.0f)
            {
                degree += 360.0f;
            }
            else if(degree > 360.0f)
            {
                degree -= 360.0f;
            }
            return degree;
        }
    }
}
