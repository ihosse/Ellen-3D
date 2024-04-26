
using UnityEngine;
public class IdleState : IState
{
    private Chomper chomper;

    public IdleState(Chomper chomper)
    {
        this.chomper = chomper;
    }

    public void Enter()
    {
        chomper.NavMeshAgent.speed = 0;
    }

    public void Exit()
    {

    }

    public void Update()
    {
        if (CheckIfTargetIsInRangeToAttack())
        {
            chomper.StateMachine.TransitionTo(chomper.StateMachine.AttackState);
            return;
        }

        if (CheckIfPlayerIsMovingAway())
        {
            chomper.StateMachine.TransitionTo(chomper.StateMachine.ChaseState);
            return;
        }

        chomper.Animator.SetFloat("Speed", 0);
    }

    private bool CheckIfTargetIsInRangeToAttack()
    {
        bool targetInRangeToAttack = false;

        Vector3 playerPosition = chomper.PlayerTarget.position;
        Vector3 chomperPosition = chomper.transform.position;

        if (Vector3.Distance(playerPosition, chomperPosition) <= chomper.AttackDistance)
        {
            targetInRangeToAttack = true;
        }


        return targetInRangeToAttack;
    }

    private bool CheckIfPlayerIsMovingAway()
    {
        bool playerMovingAway = false;

        Vector3 playerPosition = chomper.PlayerTarget.position;
        Vector3 chomperPosition = chomper.transform.position;

        if (Vector3.Distance(playerPosition, chomperPosition) > chomper.AttackDistance)
        {
            playerMovingAway = true;
        }

        return playerMovingAway;
    }

}