#if TEST
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.develop;
using until.system;
using until.modules.astral;

namespace until.test
{
    public static class TestAstralBehaviorIdentifierCategory
    {
        public static readonly int Status = 1;
    }

    public static class TestAstralRole
    {
        public static string Leader = nameof(Leader);
    }

    public static class TestAstralBehaviorIdentifier
    {
        public static readonly AstralBehaviorIdentifier StatusWait = new AstralBehaviorIdentifier(TestAstralBehaviorIdentifierCategory.Status, 1);
        public static readonly AstralBehaviorIdentifier StatusMove = new AstralBehaviorIdentifier(TestAstralBehaviorIdentifierCategory.Status, 2);
    }
}
#endif
