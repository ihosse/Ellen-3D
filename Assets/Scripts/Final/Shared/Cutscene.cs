using TMPro;
using UnityEngine;
using UnityEngine.Playables;

namespace Ellen3DFinal
{
    public class Cutscene : MonoBehaviour
    {
        [SerializeField]
        private PlayableDirector cutscene;

        [SerializeField]
        private PlayerController playerController;

        [SerializeField]
        private bool isLastLevelCutscene = false;

        public void Play()
        {
            cutscene.Play();

            playerController.DisableMovementControl(true);
            playerController.DisableAttack(true);

            if (!isLastLevelCutscene)
                cutscene.stopped += OnCutsceneEnd;
        }

        private void OnCutsceneEnd(PlayableDirector cutscene)
        {
            if (this.cutscene = cutscene)
            {
                playerController.DisableMovementControl(false);
                playerController.DisableAttack(false);
            }
        }
    }
}