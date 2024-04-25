public class StateMachine
{
    public IState CurrentState { get; private set; }

    public PatrolState PatrolState { get; private set; }
    public ChaseState ChaseState { get; private set; }
    //public HitState hitState;

    public StateMachine(Chomper chomper)
    {
        this.PatrolState = new PatrolState(chomper);
        this.ChaseState = new ChaseState(chomper);
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
