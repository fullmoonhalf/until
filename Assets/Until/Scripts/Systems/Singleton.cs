using System.Collections.Generic;
using System.Reflection;
using until.utils;
using until.develop;


namespace until.system
{
    public abstract class SingletonBase
    {
        #region シングルトン関連イベント
        /// <summary>
        /// Singleton の初期化
        /// </summary>
        public abstract void onSingletonAwake();
        /// <summary>
        /// Singleton の開始処理
        /// </summary>
        public abstract void onSingletonStart();

        /// <summary>
        /// Singleton の終了処理
        /// </summary>
        public abstract void onSingletonDestroy();
        #endregion

        #region シングルトン生成まわり
        private static List<SingletonBase> SingletonList = new List<SingletonBase>();

        /// <summary>
        /// 全てのシングルトンを生成する。
        /// </summary>
        public static void createAllSingleton()
        {
            // Singleton の生成
            var SingletonTypes = typeof(SingletonBase).getSubclasses();
            foreach (var type in SingletonTypes)
            {
                var instance = type.InvokeMember("createSingleton", BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.FlattenHierarchy, null, null, null);
                if (instance is SingletonBase singleton)
                {
                    singleton.onSingletonAwake();
                    SingletonList.Add(singleton);
                    Log.info(nameof(SingletonBase), type.FullName + " is created.");
                }
            }

            // Singleton の開始メソッドの呼び出し
            SingletonList.ForEach(singleton => singleton.onSingletonStart());
        }


        /// <summary>
        /// 全てのシングルトンを破棄する。
        /// </summary>
        public static void destroyAllSingleton()
        {
            // Singleton の終了メソッドの呼び出し
            SingletonList.ForEach(singleton => singleton.onSingletonDestroy());

            // Singleton 破棄メソッドの呼び出し
            foreach (var singleton in SingletonList)
            {
                singleton.GetType().InvokeMember("destroySingleton", BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.FlattenHierarchy, null, null, null);
            }

            // 破棄を誘発
            SingletonList.Clear();
        }

        #endregion
    }



    /// <summary>
    /// Singleton の基底クラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Singleton<T> : SingletonBase
        where T : class, new()
    {
        /// <summary>
        /// アクセッサ
        /// </summary>
        public static T Instance { get; private set; }

        #region システム関数
        /// <summary>
        /// シングルトンの初期化
        /// </summary>
        public static T createSingleton()
        {
            Instance = new T();
            return Instance;
        }

        /// <summary>
        /// シングルトンの破棄
        /// </summary>
        public static void destroySingleton()
        {
            Instance = null;
        }
        #endregion
    }
}


