using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PatrolState: IState
{
    private Chomper chomper;
    private int currentDestination;
    private int destinationLenght;

    public PatrolState(Chomper chomper)
    {
        this.chomper = chomper;
    }

    public void Enter()
    {
        currentDestination = 0;
        destinationLenght = chomper.PatrolDestinations.Length;
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
        if (CheckIfReachedDestination())
        {
            currentDestination++;

            if (currentDestination >= destinationLenght)
                currentDestination = 0;
        }

        Vector3 targetPosition = chomper.PatrolDestinations[currentDestination].position;

        chomper.NavMeshAgent.SetDestination(targetPosition);
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
