using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using until.modules.astral;

namespace until.test2
{
    public class TestAstralCharacterElement : AstralElement<TestAstralCharacterActionBase, TestAstralCharacterSprite>
    {
        public TestAstralCharacterElement(TestAstralCharacterActionBase start_action, AstralInterceptedable receiver, TestAstralCharacterSprite sprite)
            : base(start_action, receiver, sprite)
        {
        }
    }
}
