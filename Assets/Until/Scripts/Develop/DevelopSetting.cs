using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.develop
{
    public interface DevelopSetting
    {
        public string Description { get; }
        public bool IsDefault { get; }
        public bool IsValid { get; }
        public int IntNumber { get; }
        public float FloatNumber { get; }
    }
}
