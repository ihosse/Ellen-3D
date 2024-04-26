using Cinemachine;
using StarterAssets;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private AudioManager audioManager;

    [Header("Cutscene")]
    [SerializeField]
    private PlayableDirector playableDirector;

    [SerializeField]
    private CinemachineVirtualCamera playerVirtualCamera;

    [Header("GamePlay")]
    [SerializeField]
    private StarterAssetsInputs playerInputManager;

    [SerializeField]
    private Door door;

    [SerializeField]
    private MaterialChanger doorEmissiveColorChanger;

    [SerializeField]
    private PressurePad pressurePad;

    [SerializeField]
    private MaterialChanger padEmissiveColorChanger;


    private void Start()
    {
        playableDirector.stopped += OnStartCutsceneFinished;
        playerInputManager.EnableMovement(false);

        playerVirtualCamera.MoveToTopOfPrioritySubqueue();

        door.IsBlocked = true;
        doorEmissiveColorChanger.ChangeToDisabledMaterial();

        pressurePad.IsBlocked = true;
        padEmissiveColorChanger.ChangeToDisabledMaterial();
    }

    private void OnDestroy()
    {
        playableDirector.stopped -= OnStartCutsceneFinished;
    }

    public void OnKeyCollected()
    {
        door.IsBlocked = false;
        doorEmissiveColorChanger.ChangeToEnabledMaterial();

        pressurePad.IsBlocked = false;
        padEmissiveColorChanger.ChangeToEnabledMaterial();
    }
    public void OnPadActivated()
    {
        door.Open();
        playerInputManager.EnableMovement(false);

        StartCoroutine(TimedPlayerInputRecovery());
    }

    private IEnumerator TimedPlayerInputRecovery()
    {
        yield return new WaitForSeconds(7);
        playerInputManager.EnableMovement(true);
    }

    private void OnStartCutsceneFinished(PlayableDirector director)
    {
        if(playableDirector = director)
        {
            audioManager.SnapshotTransitionTo(audioManager.GamePlay, 1);
            playerInputManager.EnableMovement(true);
        }
    }

}
