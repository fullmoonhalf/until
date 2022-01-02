using UnityEngine;
using until.develop;
using until.modules.astral;
using until.modules.gamemaster;
using until.modules.gamefield;
using until.utils;


namespace until.test
{
    public class AppAstralActionNpcMove : AppAstralActionNpcBase
    {
        #region Fields
        private Vector3 _TargetPosition = Vector3.zero;
        private float _Speed = 3.0f;
        private Substance _AttackTarget = null;
        private bool TryToAttack = false;
        #endregion

        #region Methods
        public AppAstralActionNpcMove(AppSubstanceCharacter substance, Vector3 target)
             : base(substance)
        {
            _TargetPosition = target;
            _AttackTarget = Singleton.SubstanceManager.get(new GameEntitySerializableIdentifier("0"));
        }

        public override string ToString()
        {
            return $"{base.ToString()}{_TargetPosition}";
        }

        #region AstralAction
        public override void onAstralActionStart()
        {
            setNavMeshUpdate(_TargetPosition);
        }
        public override bool onAstralNpcActionUpdate(float delta_time)
        {
#if false
            if (_AttackTarget != null)
            {
                var gap = _AttackTarget.Position - RefSubstance.Position;
                var distance = gap.magnitude;
                if (distance > 3.0f && distance < 6.0f)
                {
                    if (math.getRandomIndex(500) == 0)
                    {
                        TryToAttack = true;
                        return false;
                    }
                }
            }
#endif

            if (RefSubstance.RefNavMeshAgent != null)
            {
                return linermove(delta_time);
//                return navimove(delta_time);
            }
            else
            {
                return linermove(delta_time);
            }
        }

        public override void onAstralActionEnd()
        {
            setNavMeshUpdate(null);
        }

        public override AstralAction getNextAstralAction()
        {
            if (TryToAttack)
            {
                return new AppAstralActionNpcAttack(RefSubstance, _AttackTarget);
            }

            return base.getNextAstralAction();
        }

        public override void onAstralInterceptEstablished(AstralInterfereable interferer)
        {
            setNavMeshUpdate(null);
        }

        public override void onAstralWarp(Vector3 position)
        {
            RefSubstance.Position = position;
            setNavMeshUpdate(_TargetPosition);
        }
        #endregion

        #region Action
        private void setNavMeshUpdate(Vector3? target)
        {
            if (RefSubstance.RefNavMeshAgent == null)
            {
                return;
            }
            if (target == null)
            {
                RefSubstance.RefNavMeshAgent.isStopped = true;
            }
            else
            {
                RefSubstance.RefNavMeshAgent.Warp(RefSubstance.Position);
                RefSubstance.RefNavMeshAgent.isStopped = false;
                RefSubstance.RefNavMeshAgent.speed = _Speed;
                RefSubstance.RefNavMeshAgent.SetDestination(target.Value);
                Log.info(this, nameof(setNavMeshUpdate), RefSubstance.gameObject.name, target.Value);
            }
        }

        private bool navimove(float delta_time)
        {
            if (math.checkNearlyEqual(RefSubstance.RefNavMeshAgent.remainingDistance, 0.0f, 0.1f))
            {
                RefSubstance.Position = _TargetPosition;
                return false;
            }

            RefSubstance.Position = RefSubstance.RefNavMeshAgent.nextPosition;
            return true;
        }

        private bool linermove(float delta_time)
        {
            var gap = _TargetPosition - RefSubstance.Position;
            gap.y = 0.0f;
            var speed = 3.0f * delta_time;
            var distance = gap.magnitude;
            if (speed >= distance)
            {
                RefSubstance.Position = _TargetPosition;
                RefSubstance.RefNavMeshAgent.destination = _TargetPosition;
                RefSubstance.RefNavMeshAgent.speed = _Speed;
                return false;
            }

            var direction = gap.normalized;
            RefSubstance.Position += direction * speed;
            return true;
        }
        #endregion
        #endregion
    }


    public class AppAstralActionNpcSquadMove : AppAstralActionNpcMove
    {
        public AppAstralActionNpcSquadMove(AppSubstanceCharacter substance, Vector3 target)
            : base(substance, target)
        {
        }
    }
}
