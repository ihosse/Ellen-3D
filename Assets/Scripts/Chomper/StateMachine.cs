public class StateMachine
{
    public IState CurrentState { get; private set; }

    public PatrolState PatrolState { get; private set; }
    public ChaseState ChaseState { get; private set; }
    public IdleState IdleState { get; private set; }
    public AttackState AttackState { get; private set; }
    public HurtState HurtState { get; private set; }

    public StateMachine(Chomper chomper)
    {
        this.PatrolState = new PatrolState(chomper);
        this.ChaseState = new ChaseState(chomper);
        this.IdleState = new IdleState(chomper);
        this.AttackState = new AttackState(chomper);
        this.HurtState = new HurtState(chomper);
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
