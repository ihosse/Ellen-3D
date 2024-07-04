using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider), typeof(AudioSource))]
public class PressurePad : MonoBehaviour
{
    [SerializeField]
    private Door doorToOpen;

    [SerializeField]
    private CinemachineImpulseSource impulseSource;

    [SerializeField]
    private bool isOneShot;

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
            if(impulseSource != null)
                    impulseSource.GenerateImpulse();

            //if (IsBlocked)
            //{
            //    audioSource.PlayOneShot(disabledSound);
            //}
            //else
            //{
                audioSource.PlayOneShot(enabledSound);
            doorToOpen.Open(null);

            //    if(isOneShot)
            //        collider.enabled = false;
            //}
        }
    }
}
