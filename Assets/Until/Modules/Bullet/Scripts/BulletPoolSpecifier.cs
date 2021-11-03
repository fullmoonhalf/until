using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.modules.bullet
{
    public class BulletPoolSpecifier
    {
        public string PrefabName;
        public int Count;
    }

    public class BulletPoolOrder
    {
        public BulletPoolSpecifier[] SpecifierList = null;
    }
}

