using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class Chomper : MonoBehaviour
{
    [field: SerializeField]
    public Transform PlayerTarget { get; private set; }

    

    [field: SerializeField]
    public Transform[] PatrolDestinations { get; private set; }

    [field: SerializeField]
    public float WalkSpeed { get; private set; } = 1.5f;

    [field: SerializeField]
    public float ChaseSpeed { get; private set; } = 1.5f;

    [field: SerializeField]
    public float SightDistance { get; private set; }  = 3f;
    
    [field: SerializeField]
    public float MaxSightRange { get; private set; }  = 6f;

    public Animator Animator { get; private set; }

    public NavMeshAgent NavMeshAgent { get; private set; }

    public StateMachine StateMachine { get; private set; }

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        StateMachine = new StateMachine(this);
        StateMachine.Initialize(StateMachine.PatrolState);
    }
   
    private void Update()
    {
        StateMachine.Update();
    }

    public void AttackBegin() {}
    public void AttackEnd() {}
    public void PlayStep() {}
    public void Grunt() {}
}
