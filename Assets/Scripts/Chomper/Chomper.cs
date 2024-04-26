using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator), typeof(Collider))]
public class Chomper : MonoBehaviour
{
    [field: SerializeField] public Transform PlayerTarget { get; private set; }
    [field: SerializeField] public Transform[] PatrolDestinations { get; private set; }

    [field: SerializeField] public float WalkSpeed { get; private set; } = 1f;
    [field: SerializeField] public float ChaseSpeed { get; private set; } = 1.5f;

    [field: SerializeField] public float AttackDistance { get; private set; } = 3f;
    [field: SerializeField] public float SightDistance { get; private set; }  = 5f;
    [field: SerializeField] public float MaxSightRange { get; private set; }  = 10f;

    public Animator Animator { get; private set; }
    public NavMeshAgent NavMeshAgent { get; private set; }
    public StateMachine StateMachine { get; private set; }

    private Collider collider;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        NavMeshAgent = GetComponent<NavMeshAgent>();
        collider = GetComponent<Collider>();
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

    public void AttackBegin() 
    {
        collider.enabled = true;
    }
    public void AttackEnd()
    {
        collider.enabled = false;
    }
    public void PlayStep() {}
    public void Grunt() {}
}
