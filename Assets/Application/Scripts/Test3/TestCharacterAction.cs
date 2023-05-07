using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace until.test3
{
    #region Base
    public abstract class TestCharacterAction : Action
    {
        #region Definitions
        public abstract Action onUpdateCharacter(in DeltaSituation ds);
        #endregion

        #region Properties
        protected TestCharacterContext Subject { get; private set; }
        #endregion

        #region Fields
        #endregion

        #region Methods
        public TestCharacterAction(TestCharacterContext subject)
        {
            Subject = subject;
        }

        public override Action onUpdate(in DeltaSituation ds)
        {
            var next = onUpdateCharacter(ds);
            if (next == null)
            {
                next = Subject.ActionSelector.onUpdateCharacter(ds);
            }
            return next;

        }
        #endregion

        #region Develop
#if TEST
        public override string DebugStatus
        {
            get => $"{base.DebugStatus} {Subject.DebugStatus}";
        }
#endif
        #endregion
    }
    #endregion

    #region Think
    public class TestCharacterActionSelector : TestCharacterAction
    {
        public TestCharacterActionSelector(TestCharacterContext subject)
            : base(subject)
        {
        }

        public override Action onUpdateCharacter(in DeltaSituation ds)
        {
            switch (Singleton.RandomizerManager.getGlobalInt(0, 1))
            {
                case 0: return new TestCharacterActionWait(Subject);
                case 1: return new TestCharacterActionWork(Subject);
            }
            return null;
        }
    }
    #endregion

    #region WaitAction 
    public class TestCharacterActionWait : TestCharacterAction
    {
        private float _Span = 0.0f;
        private float _Timer = 0.0f;

        public TestCharacterActionWait(TestCharacterContext subject)
            : base(subject)
        {
            _Span = Singleton.RandomizerManager.getGlobalFloat() * 3.0f + 3.0f;
        }

        public override Action onUpdateCharacter(in DeltaSituation ds)
        {
            _Timer += ds.DeltaTime;
            if (_Timer > _Span)
            {
                return null;
            }

            return this;
        }

        #region Develop
#if TEST
        public override string DebugStatus
        {
            get => $"{base.DebugStatus} {_Timer}";
        }
#endif
        #endregion
    }
    #endregion

    #region WaitAction 
    public class TestCharacterActionWork : TestCharacterAction
    {
        private float _Span = 3.0f;
        private float _Timer = 0.0f;

        public TestCharacterActionWork(TestCharacterContext subject)
            : base(subject)
        {
            _Span = Singleton.RandomizerManager.getGlobalFloat() * 3.0f + 3.0f;
        }

        public override Action onUpdateCharacter(in DeltaSituation ds)
        {
            _Timer += ds.DeltaTime;
            if (_Timer > _Span)
            {
                return null;
            }

            return this;
        }

        #region Develop
#if TEST
        public override string DebugStatus
        {
            get => $"{base.DebugStatus} {_Timer}";
        }
#endif
        #endregion
    }
    #endregion
}

