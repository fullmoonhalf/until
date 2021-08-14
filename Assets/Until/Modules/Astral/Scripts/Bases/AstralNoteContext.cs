using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace until.modules.astral
{
    public abstract class AstralNoteContext
    {
        public abstract void init(AstralSession session);
        public abstract bool update(AstralSession session);
        public abstract AstralNote exit(AstralSession session);
    }
}
