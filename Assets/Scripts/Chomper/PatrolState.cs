using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PatrolState : IState
{
    private Chomper chomper;
    private int currentDestination;
    private int destinationLenght;

    public PatrolState(Chomper chomper)
    {
        this.chomper = chomper;

        currentDestination = 0;
        destinationLenght = chomper.PatrolDestinations.Length;
    }

    public void Enter()
    {
        Debug.Log("PatrolState");
        chomper.NavMeshAgent.speed = chomper.WalkSpeed;
        
    }

    public void Exit()
    {

    }

    public void Update()
    {
        if (CheckIfPlayerIsInSight())
        {
            chomper.StateMachine.TransitionTo(chomper.StateMachine.ChaseState);
            return;
        }


        if (CheckIfReachedDestination())
        {
            currentDestination++;

            if (currentDestination >= destinationLenght)
                currentDestination = 0;
        }

        Vector3 targetPosition = chomper.PatrolDestinations[currentDestination].position;
        chomper.NavMeshAgent.SetDestination(targetPosition);

        chomper.Animator.SetFloat("Speed", chomper.NavMeshAgent.velocity.magnitude);
    }

    private bool CheckIfPlayerIsInSight()
    {
        bool playerInSight = false;

        Vector3 playerPosition = chomper.PlayerTarget.position;
        Vector3 chomperPosition = chomper.transform.position;
        float sightDistance = chomper.SightDistance;

        if (Vector3.Distance(playerPosition, chomperPosition) < sightDistance)
        {
            playerInSight = true;
        }

        return playerInSight;
    }

    private bool CheckIfReachedDestination()
    {
        bool destinationReached = false;

        Vector3 chomperPosition = chomper.transform.position;
        Vector3 destinationPosition = chomper.PatrolDestinations[currentDestination].position;

        if (Vector3.Distance(chomperPosition, destinationPosition) < .2f)
            destinationReached = true;

        return destinationReached;
    }
}
