using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



namespace until.modules.gamemaster
{
    [AttributeUsage(AttributeTargets.Enum, Inherited = false, AllowMultiple = false)]
    sealed class GameEntityIdentifiableAttribute : Attribute
    {
    }
}

