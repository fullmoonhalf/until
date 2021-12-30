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

        #region AstralAction
        public override void onAstralActionStart()
        {
            if (RefSubstance.RefNavMeshAgent != null)
            {
                RefSubstance.RefNavMeshAgent.destination = _TargetPosition;
                RefSubstance.RefNavMeshAgent.speed = _Speed;
            }
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
        }

        public override void onAstralInterceptEstablished(AstralInterfereable interferer)
        {
        }
        #endregion


        #region Action
        private bool navimove(float delta_time)
        {
            var distance = _Speed * delta_time;
            if (RefSubstance.RefNavMeshAgent.remainingDistance < distance)
            {
                RefSubstance.Position = _TargetPosition;
                return false;
            }

            // 移動できなくていったんあきらめる(仮)
            if (math.checkNearlyEqual(RefSubstance.RefNavMeshAgent.velocity.magnitude, 0.0f))
            {
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
