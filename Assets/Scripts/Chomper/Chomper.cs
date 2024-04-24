using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Chomper : MonoBehaviour
{

    [field: SerializeField]
    public Transform PlayerTarget { get; private set; }

    [field: SerializeField]
    public Transform[] PatrolDestinations { get; private set; }

    public NavMeshAgent NavMeshAgent { get; private set; }

    private StateMachine stateMachine;

    private void Start()
    {
        stateMachine = new StateMachine(this);
        stateMachine.Initialize(stateMachine.patrolState);

        NavMeshAgent = GetComponent<NavMeshAgent>();
    }
   
    private void Update()
    {
        stateMachine.Update();
    }
}
