using UnityEngine;

public class ChaseState : IState
{
    private Chomper chomper;

    public ChaseState(Chomper chomper)
    {
        this.chomper = chomper;
    }

    public void Enter()
    {
        Debug.Log("ChaseState");
        chomper.NavMeshAgent.speed = chomper.ChaseSpeed;
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

        if (CheckIfTargetIsOutOfRange())
        {
            chomper.StateMachine.TransitionTo(chomper.StateMachine.PatrolState);
            return;
        }

        chomper.Animator.SetFloat("Speed", chomper.NavMeshAgent.velocity.magnitude);

        Vector3 targetPosition = chomper.PlayerTarget.position;
        chomper.NavMeshAgent.SetDestination(targetPosition);
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

    private bool CheckIfTargetIsOutOfRange()
    {
        bool targetIsOutOfRange = false;

        Vector3 playerPosition = chomper.PlayerTarget.position;
        Vector3 chomperPosition = chomper.transform.position;
        float outOfRangeDistance = chomper.MaxSightRange;

        if (Vector3.Distance(playerPosition, chomperPosition) >= outOfRangeDistance)
        {
            targetIsOutOfRange = true;
        }

        return targetIsOutOfRange;
    }
}
