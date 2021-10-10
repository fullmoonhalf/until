using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace until.system.defines
{
    public static class Resources
    {
        public static readonly string SystemContainer = nameof(SystemContainer);
        public static readonly string DevelopContainer = "DevelopContainer";
    }

    public static class ExecutionOrder
    {
        public const int Develop_Head_00 = -2000;
        public const int Develop_Head_10 = Develop_Head_00 + 10;

        public const int System_Head_00 = -1000;
        public const int System_Head_10 = System_Head_00 + 10;
        public const int System_Head_20 = System_Head_00 + 20;
        public const int System_Head_30 = System_Head_00 + 30;
        public const int System_Head_40 = System_Head_00 + 40;
        public const int System_Head_50 = System_Head_00 + 50;
        public const int System_Head_60 = System_Head_00 + 60;
        public const int System_Head_70 = System_Head_00 + 70;
        public const int System_Head_80 = System_Head_00 + 80;

        public const int ApplicationStart = -500;
        public const int ApplicationEnd = 500;

        public const int Develop_Tail_00 = 2000;
        public const int Develop_Tail_10 = Develop_Tail_00 + 10;

        public const int Undefined = 0;
    }
}
