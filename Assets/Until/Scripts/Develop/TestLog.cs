using System.Diagnostics;


namespace until.develop
{
    /// <summary>
    /// UnitTest �Ƃ���g�݂����Ƃ��p�̃��O�o�͊֐�
    /// �Ƃ�܃C���^�[�t�F�C�X��p�ӂ���
    /// </summary>
    public class TestLog : Log
    {
        [Conditional("TEST")]
        public static void test(object Source, string Text, params object[] Args)
        {
            var Message = $"*[{Source.GetType().Name}] " + string.Format(Text, Args);
            UnityEngine.Debug.LogFormat(Message);
        }

        [Conditional("TEST")]
        public static void test(string Source, string Text, params object[] Args)
        {
            var Message = $"*[{Source}] " + string.Format(Text, Args);
            UnityEngine.Debug.LogFormat(Message);
        }
    }
}
