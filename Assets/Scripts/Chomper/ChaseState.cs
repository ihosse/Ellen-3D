
using UnityEngine;

public class ChaseState: IState
{
    private Chomper chomper;

    public ChaseState(Chomper chomper)
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
