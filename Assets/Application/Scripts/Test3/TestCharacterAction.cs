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

        #region Fields
        protected TestCharacterContext _Subject;
        #endregion

        #region Methods
        public TestCharacterAction(TestCharacterContext subject)
        {
            _Subject = subject;
        }

        public override Action onUpdate(in DeltaSituation ds)
        {
            return onUpdateCharacter(ds);
        }
        #endregion

        #region Develop
#if TEST
        public override string DebugStatus
        {
            get => $"{base.DebugStatus} {_Subject.DebugStatus}";
        }
#endif
        #endregion
    }
    #endregion

    #region WaitAction 
    public class TestCharacterActionWait : TestCharacterAction
    {
        private float _Span = 3.0f;
        private float _Timer = 0.0f;

        public TestCharacterActionWait(TestCharacterContext subject)
            : base(subject)
        {
        }

        public override Action onUpdateCharacter(in DeltaSituation ds)
        {
            _Timer += ds.DeltaTime;
            if (_Timer > _Span)
            {
                return new TestCharacterActionWork(_Subject);
            }

            return this;
        }
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
        }

        public override Action onUpdateCharacter(in DeltaSituation ds)
        {
            _Timer += ds.DeltaTime;
            if (_Timer > _Span)
            {
                return new TestCharacterActionWait(_Subject);
            }

            return this;
        }
    }
    #endregion
}

