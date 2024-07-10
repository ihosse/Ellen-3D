using UnityEngine;

namespace Ellen3DStart
{
    public class HurtState : IState
    {
        private Chomper chomper;

        private bool isKnockedBack = false;
        private float timeToRecover = 1.2f;
        private float recoverTimeCount;

        private Vector3 knockbackDirection;
        private float knockbackForce = 100;

        public HurtState(Chomper chomper)
        {
            this.chomper = chomper;
        }

        public void Enter()
        {
            chomper.Collider.enabled = false;

            //needed to set Attack to false because the Chomper can be hit during an attack
            chomper.Animator.SetBool("Attack", false);
            chomper.Animator.SetTrigger("Hit");

            isKnockedBack = true;

            Vector3 playerPosition = chomper.PlayerTarget.transform.position;
            Vector3 chomperPosition = chomper.transform.position;
            Vector3 knockbackDirection = chomper.PlayerTarget.forward.normalized;

            chomper.NavMeshAgent.SetDestination(knockbackDirection * 3);
            chomper.NavMeshAgent.speed = knockbackForce;
            chomper.NavMeshAgent.angularSpeed = 0;

            recoverTimeCount = Time.time;

            chomper.ApllyFreezeScreenEffect();
        }

        public void Exit()
        {
        }

        public void Update()
        {
            if (isKnockedBack)
            {
                ApplyKnockback(knockbackDirection);
            }
            else
                chomper.StateMachine.TransitionTo(chomper.StateMachine.ChaseState);
        }

        private void ApplyKnockback(Vector3 knockbackDirection)
        {
            Debug.DrawLine(chomper.transform.position, knockbackDirection * 3, Color.red);

            if (recoverTimeCount + timeToRecover < Time.time)
            {
                chomper.Collider.enabled = true;
                chomper.NavMeshAgent.isStopped = false;
                isKnockedBack = false;
                chomper.NavMeshAgent.angularSpeed = 120;
            }
        }
    }
}