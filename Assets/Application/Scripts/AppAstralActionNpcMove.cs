using UnityEngine;
using until.develop;
using until.modules.astral;
using until.utils;


namespace until.test
{
    public class AppAstralActionNpcMove : AppAstralActionNpcBase
    {
        #region Fields
        private Vector3 _TargetPosition = Vector3.zero;
        private float _Speed = 3.0f;
        #endregion

        #region Methods
        public AppAstralActionNpcMove(AppSubstanceCharacter substance, AppAstralActionNpcCogitation cogitation, Vector3 target)
             : base(substance, cogitation)
        {
            _TargetPosition = target;
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
            if (RefSubstance.RefNavMeshAgent != null)
            {
                return navimove(delta_time);
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

        public override void onAstralInterceptEstablished(AstralInterfereable interferer)
        {
            setNavMeshUpdate(null);
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
                RefSubstance.RefNavMeshAgent.isStopped = false;
                RefSubstance.RefNavMeshAgent.SetDestination(target.Value);
                RefSubstance.RefNavMeshAgent.speed = _Speed;
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
}
