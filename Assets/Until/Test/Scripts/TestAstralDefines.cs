﻿#if TEST
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.develop;
using until.system;
using until.modules.astral;
using until.modules.gamemaster;

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

    public static class TestGMParameterIdentifier
    {
        public static readonly GameParameterIdentifier HP = new GameParameterIdentifier("HP");
    }

    public static class TestGMAffairIdentifier
    {
        public static readonly GameAffairIdentifier Initial = new GameAffairIdentifier("Initial");
    }
}
#endif
