using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [field: SerializeField]
    public AudioMixerSnapshot Opening { get; private set; }

    [field: SerializeField]
    public AudioMixerSnapshot GamePlay { get; private set; }

    public void SnapshotTransitionTo(AudioMixerSnapshot snapShot, float transitionTime)
    {
        snapShot.TransitionTo(transitionTime);
    }
}
