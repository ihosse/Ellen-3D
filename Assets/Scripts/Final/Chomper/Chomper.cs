using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Ellen3DFinal
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Animator), typeof(Collider))]
    public class Chomper : MonoBehaviour
    {
        [SerializeField]
        private bool startOnIdleState = true;
        [field: SerializeField] public Transform PlayerTarget { get; private set; }
        [field: SerializeField] public Transform[] PatrolDestinations { get; private set; }

        [field: SerializeField] public float WalkSpeed { get; private set; } = 1f;
        [field: SerializeField] public float ChaseSpeed { get; private set; } = 1.5f;

        [field: SerializeField] public float AttackDistance { get; private set; } = 3f;
        [field: SerializeField] public float SightDistance { get; private set; } = 5f;
        [field: SerializeField] public float MaxSightRange { get; private set; } = 10f;

        [SerializeField]
        private CameraImpulse cameraImpulse;

        public Animator Animator { get; private set; }
        public NavMeshAgent NavMeshAgent { get; private set; }
        public StateMachine StateMachine { get; private set; }

        public ChomperSound Sound { get; private set; }

        public Collider Collider { get; private set; }

        private void Awake()
        {
            Animator = GetComponent<Animator>();
            NavMeshAgent = GetComponent<NavMeshAgent>();
            Collider = GetComponent<Collider>();
            Sound = GetComponent<ChomperSound>();
        }
        private void Start()
        {
            StateMachine = new StateMachine(this);

            if (startOnIdleState)
                StateMachine.Initialize(StateMachine.IdleState);
            else
                StateMachine.Initialize(StateMachine.PatrolState);
        }

        private void Update()
        {
            StateMachine.Update();
        }

        public void StartPatrol()
        {
            StateMachine.TransitionTo(StateMachine.PatrolState);
            StateMachine.IdleState.IsEnabled = true;
        }

        public void Death()
        {
            StateMachine.TransitionTo(StateMachine.DeathState);
        }

        public void Hit()
        {
            StateMachine.TransitionTo(StateMachine.HurtState);
        }

        public void ApllyFreezeScreenEffect()
        {
            StartCoroutine(FreezeScreenEffectTimer());
        }

        private IEnumerator FreezeScreenEffectTimer()
        {
            yield return new WaitForSecondsRealtime(.15f);
            Time.timeScale = 0f;
            Sound.OnHit();
            yield return new WaitForSecondsRealtime(.25f);
            if (cameraImpulse != null) cameraImpulse.ApplyImpulse();
            Time.timeScale = 1f;
        }

        public void AttackBegin()
        {
            Sound.OnAttack();
        }
        public void AttackEnd()
        {
        }
        public void PlayStep()
        {
            Sound.OnFootstep();
        }
        public void Grunt()
        {


        }
    }
}
