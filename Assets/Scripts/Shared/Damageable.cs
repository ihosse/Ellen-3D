using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [SerializeField]
    private int life = 1;

    [SerializeField]
    private bool isImmortal;

    public UnityEvent OnHit;
    public UnityEvent OnKill;
    public void Hit()
    {
        if(!isImmortal)
            life--;

        if (life <= 0)
            OnKill?.Invoke();
        else
            OnHit?.Invoke();
    }
}
