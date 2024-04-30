using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Damager : MonoBehaviour
{
    public UnityEvent OnHitSomething;
    private void OnTriggerEnter(Collider other)
    {
        OnHitSomething?.Invoke();


        if (other.TryGetComponent<Damageable>(out Damageable damageable))
        {
            damageable.Hit();
        }
    }
}
