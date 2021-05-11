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
        public const int System_Head_20 = -1000 + 20;
        public const int System_Head_30 = -1000 + 30;
        public const int System_Head_40 = -1000 + 40;
        public const int System_Head_50 = -1000 + 50;
        public const int System_Head_60 = -1000 + 60;
        public const int System_Head_70 = -1000 + 70;
        public const int System_Head_80 = -1000 + 80;

        public const int ApplicationStart = -500;
        public const int ApplicationEnd = 500;
    }
}
