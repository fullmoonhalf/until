using System.Diagnostics;


namespace until.develop
{
    public static class Log
    {
        [Conditional("TEST")]
        public static void fatal(object Source, string Text, params object[] Args)
        {
            var Message = $"[{Source.GetType().Name}] " + string.Format(Text, Args);
            UnityEngine.Debug.LogAssertionFormat(Message);
        }

        [Conditional("TEST")]
        public static void fatal(string Source, string Text, params object[] Args)
        {
            var Message = $"[{Source}] " + string.Format(Text, Args);
            UnityEngine.Debug.LogAssertionFormat(Message);
        }

        [Conditional("TEST")]
        public static void error(object Source, string Text, params object[] Args)
        {
            var Message = $"[{Source.GetType().Name}] " + string.Format(Text, Args);
            UnityEngine.Debug.LogErrorFormat(Message);
        }

        [Conditional("TEST")]
        public static void error(string Source, string Text, params object[] Args)
        {
            var Message = $"[{Source}] " + string.Format(Text, Args);
            UnityEngine.Debug.LogErrorFormat(Message);
        }

        [Conditional("TEST")]
        public static void warning(object Source, string Text, params object[] Args)
        {
            var Message = $"[{Source.GetType().Name}] " + string.Format(Text, Args);
            UnityEngine.Debug.LogWarningFormat(Message);
        }

        [Conditional("TEST")]
        public static void warning(string Source, string Text, params object[] Args)
        {
            var Message = $"[{Source}] " + string.Format(Text, Args);
            UnityEngine.Debug.LogWarningFormat(Message);
        }

        [Conditional("TEST")]
        public static void info(object Source, string Text, params object[] Args)
        {
            var Message = $"[{Source.GetType().Name}] " + string.Format(Text, Args);
            UnityEngine.Debug.LogFormat(Message);
        }

        [Conditional("TEST")]
        public static void info(string Source, string Text, params object[] Args)
        {
            var Message = $"[{Source}] " + string.Format(Text, Args);
            UnityEngine.Debug.LogFormat(Message);
        }

        [Conditional("VERBOSE")]
        public static void verbose(object Source, string Text, params object[] Args)
        {
            var Message = $"[{Source.GetType().Name}] " + string.Format(Text, Args);
            UnityEngine.Debug.LogFormat(Message);
        }

        [Conditional("VERBOSE")]
        public static void verbose(string Source, string Text, params object[] Args)
        {
            var Message = $"[{Source}] " + string.Format(Text, Args);
            UnityEngine.Debug.LogFormat(Message);
        }
    }
}
