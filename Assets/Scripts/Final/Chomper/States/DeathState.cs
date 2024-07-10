using UnityEngine;

namespace Ellen3DFinal
{
    public class DeathState : IState
    {
        private Chomper chomper;


        public DeathState(Chomper chomper)
        {
            this.chomper = chomper;
        }
        public void Enter()
        {
            chomper.Animator.SetTrigger("Death");
            chomper.NavMeshAgent.isStopped = true;
            chomper.Collider.enabled = false;
            chomper.ApllyFreezeScreenEffect();
        }

        public void Exit()
        {
        }

        public void Update()
        {

        }
    }
}
