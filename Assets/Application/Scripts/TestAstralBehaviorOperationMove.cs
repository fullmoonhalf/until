using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using until.modules.astral;


namespace until.test
{
    public class TestAstralBehaviorOperationMove : AstralBehaviorOperation
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="category"></param>
        /// <param name="action"></param>
        public TestAstralBehaviorOperationMove(int category, int action)
            : base(category, action)
        {
        }

        /// <summary>
        /// 引数生成
        /// </summary>
        /// <returns></returns>
        public override AstralBehaviorRequestArgument createArgument()
        {
            return new TestAstralBehaviorOperationMoveArgument();
        }
    }

    public class TestAstralBehaviorOperationMoveArgument : AstralBehaviorRequestArgument
    {
    }
}
