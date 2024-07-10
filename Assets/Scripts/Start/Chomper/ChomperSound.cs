using UnityEngine;

namespace Ellen3DStart
{
    [RequireComponent(typeof(AudioSource))]
    public class ChomperSound : MonoBehaviour
    {
        public AudioClip[] FootstepAudioClips;
        public AudioClip[] HitAudioClips;
        public AudioClip[] AttackAudioClips;

        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void OnHit()
        {
            if (HitAudioClips.Length > 0)
            {
                var index = Random.Range(0, HitAudioClips.Length);
                audioSource.PlayOneShot(HitAudioClips[index]);
            }
        }

        public void OnFootstep()
        {
            if (FootstepAudioClips.Length > 0)
            {
                var index = Random.Range(0, FootstepAudioClips.Length);
                audioSource.PlayOneShot(FootstepAudioClips[index]);
            }
        }

        public void OnAttack()
        {
            if (AttackAudioClips.Length > 0)
            {
                var index = Random.Range(0, AttackAudioClips.Length);
                audioSource.PlayOneShot(AttackAudioClips[index]);
            }
        }
    }
}
