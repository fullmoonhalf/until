using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.system.defines
{
    public static class Resources
    {
        public static readonly string SystemContainer = nameof(SystemContainer);
    }

    public static class ExecutionOrder
    {
        public const int System_Head_00 = -1000;
        public const int System_Head_10 = -1000 + 10;

        public const int ApplicationStart = -500;
        public const int ApplicationEnd = 500;
    }
}
