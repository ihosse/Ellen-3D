using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

namespace Ellen3DFinal
{
    public class Key : MonoBehaviour
    {
        public UnityEvent OnCollect;

        [SerializeField]
        private ParticleSystem effect;

        [SerializeField]
        private AudioClip audioClip;

        [SerializeField]
        private CinemachineImpulseSource impulseSource;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (effect != null)
                    CreateParticle();

                if (impulseSource != null)
                    impulseSource.GenerateImpulse();

                if (audioClip != null)
                    AudioSource.PlayClipAtPoint(audioClip, transform.position);

                gameObject.SetActive(false);

                OnCollect.Invoke();
            }
        }

        private void CreateParticle()
        {
            GameObject particleEffect = Instantiate(effect.gameObject);
            particleEffect.transform.position = transform.position;
            Destroy(particleEffect, 1);
        }
    }
}
