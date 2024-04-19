using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class PressurePad : MonoBehaviour
{
    public UnityEvent OnPress;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPress?.Invoke();
        }
    }
}
