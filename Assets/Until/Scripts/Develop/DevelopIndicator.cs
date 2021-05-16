using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.develop
{
    public interface DevelopIndicator
    {
        public string DisplayText { get; }
        public int Width { get; }
        public int Height { get; }
    }
}
