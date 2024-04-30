using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSound : MonoBehaviour
{
    public AudioClip LandingAudioClip;
    public AudioClip[] FootstepAudioClips;
    public AudioClip[] AttackAudioClips;
    public AudioClip[] WeaponAudioClips;
    public AudioClip[] HitAudioClips;
    public AudioClip[] HurtAudioClips;

    [Range(0, 1)] public float FootstepAudioVolume = 0.5f;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void HitSound()
    {
        if (HitAudioClips.Length > 0)
        {
            var index = Random.Range(0, HitAudioClips.Length);
            audioSource.PlayOneShot(HitAudioClips[index]);
        }
    }

    public void OnHurt()
    {
        if (HurtAudioClips.Length > 0)
        {
            var index = Random.Range(0, HurtAudioClips.Length);
            audioSource.PlayOneShot(HurtAudioClips[index]);
        }
    }

    public void OnAttackSound()
    {
        if (AttackAudioClips.Length > 0)
        {
            var index = Random.Range(0, AttackAudioClips.Length);
            audioSource.PlayOneShot(AttackAudioClips[index]);
        }
        
        if (WeaponAudioClips.Length > 0)
        {
            var index = Random.Range(0, WeaponAudioClips.Length);
            audioSource.PlayOneShot(WeaponAudioClips[index]);
        }
    }

    private void OnFootstep(AnimationEvent animationEvent)
    {
        if (animationEvent.animatorClipInfo.weight > 0.5f)
        {
            if (FootstepAudioClips.Length > 0)
            {
                var index = Random.Range(0, FootstepAudioClips.Length);
                audioSource.PlayOneShot(FootstepAudioClips[index]);
            }
        }
    }

    private void OnLand(AnimationEvent animationEvent)
    {
        if (animationEvent.animatorClipInfo.weight > 0.2f)
        {
            audioSource.PlayOneShot(LandingAudioClip);
        }
    }
}
