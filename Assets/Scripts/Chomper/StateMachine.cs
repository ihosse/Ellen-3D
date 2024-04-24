public class StateMachine
{
    public IState CurrentState { get; private set; }

    public PatrolState patrolState { get; private set; }
    //public ChaseState chaseState;
    //public HitState hitState;

    public StateMachine(Chomper chomper)
    {
        this.patrolState = new PatrolState(chomper);
    }

    public void Initialize(IState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void TransitionTo(IState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        nextState.Enter();
    }

    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }
}
