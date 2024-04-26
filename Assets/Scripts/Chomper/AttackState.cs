using UnityEngine;

public class AttackState : IState
{
    private Chomper chomper;
    private float AttackAnimationTime = .8f;
    private float startTime;

    public AttackState(Chomper chomper)
    {
        this.chomper = chomper;
    }

    public void Enter()
    {
        chomper.NavMeshAgent.speed = 0;
        chomper.transform.LookAt(chomper.PlayerTarget.transform.position);
        startTime = Time.time;
    }

    public void Exit()
    {

    }

    public void Update()
    {
        if (CheckIfAttackAnimationEnded())
        {
            chomper.Animator.SetBool("Attack", false);
            chomper.StateMachine.TransitionTo(chomper.StateMachine.IdleState);
            return;
        }

        chomper.Animator.SetBool("Attack", true);
    }

    private bool CheckIfAttackAnimationEnded()
    {
        if (startTime + AttackAnimationTime > Time.time)
            return false;
        else
            return true;
    }
}
