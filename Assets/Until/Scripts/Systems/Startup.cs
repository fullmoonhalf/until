using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.develop;


namespace until.system
{
    public class Startup
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void onApplicationStart()
        {
            Log.info(nameof(Startup), "onApplicationStart - begin");
            SingletonBase.createAllSingleton();

            var SystemObject = GameObject.Instantiate(Resources.Load(defines.Resources.SystemContainer));
            GameObject.DontDestroyOnLoad(SystemObject);

            Log.info(nameof(Startup), "onApplicationStart - end");
        }
    }
}

