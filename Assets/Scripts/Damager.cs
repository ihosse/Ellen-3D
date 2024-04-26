using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Damager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Damageable>(out Damageable damageable))
        {
            damageable.Hit();
        }
    }
}
