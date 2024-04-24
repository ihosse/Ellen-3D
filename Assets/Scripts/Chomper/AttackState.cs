using UnityEngine;

public class AttackState : IState
{
    private Chomper chomper;

    public AttackState(Chomper chomper)
    {
        this.chomper = chomper;
    }

    public void Enter()
    {
        Debug.Log("enter");
    }

    public void Exit()
    {
        Debug.Log("Exit");
    }

    public void Update()
    {
        Debug.Log("Update");
    }
}
