using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public UnityEvent OnHit;
    public void Hit()
    {
        OnHit?.Invoke();
    }
}
