using UnityEngine;
using UnityEngine.Audio;
using static System.TimeZoneInfo;

namespace Ellen3DFinal
{
    public class AudioManager : MonoBehaviour
    {
        [field: SerializeField]
        public AudioMixerSnapshot Opening { get; private set; }

        [field: SerializeField]
        public AudioMixerSnapshot Ambience { get; private set; }

        [field: SerializeField]
        public AudioMixerSnapshot Exploration { get; private set; }

        [field: SerializeField]
        public AudioMixerSnapshot Combat { get; private set; }

        [field: SerializeField]
        public AudioMixerSnapshot Ending { get; private set; }

        public void SnapshotTransitionTo(AudioMixerSnapshot snapShot, float transitionTime)
        {
            snapShot.TransitionTo(transitionTime);
        }

        public void SignalTransitionToCombat()
        {
            SnapshotTransitionTo(Combat, 1);
        }

        public void SignalTransitionToExploration()
        {
            SnapshotTransitionTo(Exploration, 1);
        }

        public void SignalTransitionToAmbience()
        {
            SnapshotTransitionTo(Ambience, 1);
        }
    }
}
