using System.Collections;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    [SerializeField]
    private AudioManager audioManager;

    [SerializeField]
    private PlayerController playerController;


    public void Play() 
    {
        StartCoroutine(WaitAndOpenDoor());
    }
    public IEnumerator WaitAndOpenDoor()
    {
        yield return new WaitForSeconds(.5f);
        audioManager.SnapshotTransitionTo(audioManager.Exploration, 1);

        playerController.DisableMovementControl(true);
        playerController.DisableAttack(true);

        yield return new WaitForSeconds(3);

        //doorEnd.IsLocked = false;
        //doorEndEmissiveColorChanger.ChangeToEnabledMaterial();

        //doorEnd.Open();

        StartCoroutine(WaitAndEnablePlayerControl());
    }

    private IEnumerator WaitAndEnablePlayerControl()
    {
        yield return new WaitForSeconds(7);
        playerController.DisableMovementControl(false);

        //if (playerHasWeapon)
        //{
        //    playerController.DisableAttack(false);
        //}
    }
}
