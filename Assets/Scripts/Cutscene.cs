using UnityEngine;
using UnityEngine.Playables;

public class Cutscene : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector cutscene;

    [SerializeField]
    private PlayerController playerController;

    public void Play()
    {
        cutscene.Play();
        cutscene.stopped += OnCutsceneEnd;

        playerController.DisableMovementControl(true);
        playerController.DisableAttack(true);
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