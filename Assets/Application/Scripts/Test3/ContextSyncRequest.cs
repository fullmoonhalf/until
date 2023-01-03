using System.Collections.Generic;
using until.system;


namespace until.test3
{
    public abstract class ContextSyncRequest
    {
        public int Priority = 0;
        public Context Requester = null;
        public Context[] Targets = null;
    }
}
