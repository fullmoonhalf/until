#if TEST
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.develop
{
    public interface DevelopCommand
    {
        public string Description { get; }
        public void execute();
    }
}
#endif
