using Cinemachine;
using UnityEngine;

namespace Ellen3DFinal
{
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

        [SerializeField]
        private MaterialChanger materialChanger;

        private AudioSource audioSource;
        private new Collider collider;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            collider = GetComponent<Collider>();
        }

        public void Activate()
        {
            materialChanger.ChangeToEnabledMaterial();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (impulseSource != null)
                    impulseSource.GenerateImpulse();

                if (doorToOpen.IsLocked == false)
                {
                    audioSource.PlayOneShot(enabledSound);
                    doorToOpen.Open();

                    if (isOneShot)
                        collider.enabled = false;
                }
                else
                {
                    audioSource.PlayOneShot(disabledSound);
                }
            }
        }
    }
}
