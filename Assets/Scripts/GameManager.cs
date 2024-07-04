using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private AudioManager audioManager;

    [SerializeField]
    private CinemachineVirtualCamera playerVirtualCamera;

    [Header("Cutscenes")]
    [SerializeField]
    private PlayableDirector openingCutscene;

    [SerializeField]
    private PlayableDirector chomperCutscene;

    [SerializeField]
    private PlayableDirector endingCutscene;

    [Header("GamePlay")]
    [SerializeField]
    private PlayerController playerController;

    [Space(10)]

    [SerializeField]
    private Chomper chomper;

    [Space(10)]

    [SerializeField]
    private Door doorCave;

    [SerializeField]
    private MaterialChanger doorCaveEmissiveColorChanger;

    [SerializeField]
    private PressurePad pressurePad;

    [SerializeField]
    private MaterialChanger padEmissiveColorChanger;

    [Space(10)]

    [SerializeField]
    private Door doorEnd;

    [SerializeField]
    private MaterialChanger doorEndEmissiveColorChanger;

    private bool playerHasWeapon;

    private void Start()
    {
        openingCutscene.stopped += OnStartCutsceneFinished;
        playerController.DisableMovementControl(true);
        playerController.DisableAttack(true);

        playerVirtualCamera.MoveToTopOfPrioritySubqueue();

        doorCave.IsLocked = true;
        doorCaveEmissiveColorChanger.ChangeToDisabledMaterial();

        doorEnd.IsLocked = true;
        doorEndEmissiveColorChanger.ChangeToDisabledMaterial();

        // pressurePad.IsBlocked = true;
        padEmissiveColorChanger.ChangeToDisabledMaterial();

        chomper.gameObject.SetActive(false);

        playerHasWeapon = false;
    }

    private void OnDestroy()
    {
        openingCutscene.stopped -= OnStartCutsceneFinished;
        chomperCutscene.stopped -= OnChomperCutsceneFinished;
        endingCutscene.stopped -= OnEndingCutsceneFinished;
    }

    private void OnStartCutsceneFinished(PlayableDirector director)
    {
        audioManager.SnapshotTransitionTo(audioManager.Ambience, 1);

        if (openingCutscene = director)
        {
            playerController.DisableMovementControl(false);
            if (playerHasWeapon)
            {
                playerController.DisableAttack(false);
            }
        }
    }

    public void OnKeyCollected()
    {
        doorCave.IsLocked = false;
        doorCaveEmissiveColorChanger.ChangeToEnabledMaterial();

        //pressurePad.IsBlocked = false;
        padEmissiveColorChanger.ChangeToEnabledMaterial();
    }
    
    public void OnPadActivated()
    {
        //doorCave.Open();
        playerController.DisableMovementControl(true);
        playerController.DisableAttack(true);

        audioManager.SnapshotTransitionTo(audioManager.Exploration, 1);
        StartCoroutine(WaitAndEnablePlayerControl());
    }

    private IEnumerator WaitAndEnablePlayerControl()
    {
        yield return new WaitForSeconds(7);
        playerController.DisableMovementControl(false);

        if (playerHasWeapon)
        {
            playerController.DisableAttack(false);
        }
    }

    public void OnStaffCollected()
    {
        chomper.gameObject.SetActive(true);
        chomperCutscene.Play();

        playerHasWeapon = true;

        chomperCutscene.stopped += OnChomperCutsceneFinished;

        audioManager.SnapshotTransitionTo(audioManager.Ambience, 1);

        playerController.OnStaffCollected();
        playerHasWeapon = true;

        playerController.DisableMovementControl(true);
        playerController.DisableAttack(true);
    }

    private void OnChomperCutsceneFinished(PlayableDirector director)
    {
        if (chomperCutscene = director)
        {
            audioManager.SnapshotTransitionTo(audioManager.Combat, 1);
            playerController.DisableMovementControl(false);
            chomper.StartPatrol();

            if (playerHasWeapon)
            {
                playerController.DisableAttack(false);
            }
        }
    }

    public void OnEnemyKilled()
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

        doorEnd.IsLocked = false;
        doorEndEmissiveColorChanger.ChangeToEnabledMaterial();

        //doorEnd.Open();

        StartCoroutine(WaitAndEnablePlayerControl());
    }

    public void OnEnterFinalDoor()
    {
        playerController.DisableMovementControl(true);
        playerController.DisableAttack(true);
    }

    public void OnEnding()
    {
        playerController.DisableMovementControl(true);
        playerController.DisableAttack(true);

        endingCutscene.stopped += OnEndingCutsceneFinished;

        audioManager.SnapshotTransitionTo(audioManager.Ending, 2);

        endingCutscene.Play();
    }

    private void OnEndingCutsceneFinished(PlayableDirector director)
    {
        SceneManager.LoadScene(0);
    }

}
