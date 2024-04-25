
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
        chomper.NavMeshAgent.speed = chomper.ChaseSpeed;
    }

    public void Exit()
    {
    }

    public void Update()
    {
        if (CheckIfTargetIsOutOfRange())
        {
            chomper.StateMachine.TransitionTo(chomper.StateMachine.PatrolState);
            return;
        }

        chomper.Animator.SetFloat("Speed", chomper.NavMeshAgent.velocity.magnitude);

        Vector3 targetPosition = chomper.PlayerTarget.position;
        chomper.NavMeshAgent.SetDestination(targetPosition);
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
