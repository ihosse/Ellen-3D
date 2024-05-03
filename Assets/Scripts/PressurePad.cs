using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider), typeof(AudioSource))]
public class PressurePad : MonoBehaviour
{
    public UnityEvent OnPress;
    public bool IsBlocked { get; set; }

    [SerializeField]
    private bool shouldRunOnce;

    [SerializeField]
    private AudioClip disabledSound;

    [SerializeField]
    private AudioClip enabledSound;

    private AudioSource audioSource;
    private new Collider collider;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        collider = GetComponent<Collider>();    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (IsBlocked)
            {
                audioSource.PlayOneShot(disabledSound);
            }
            else
            {
                audioSource.PlayOneShot(enabledSound);
                OnPress?.Invoke();

                if(shouldRunOnce)
                    collider.enabled = false;
            }
        }
    }
}
