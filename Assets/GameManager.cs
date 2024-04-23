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

    [Header("GamePlay")]
    [SerializeField]
    private StarterAssetsInputs playerInputManager;

    [SerializeField]
    private ThirdPersonController thirdPersonController;

    [SerializeField]
    private Door door;

    [SerializeField]
    private EmissiveColorChanger doorEmissiveColorChanger;

    [SerializeField]
    private PressurePad pressurePad;

    [SerializeField]
    private EmissiveColorChanger padEmissiveColorChanger;


    private void Start()
    {
        playableDirector.stopped += OnStartCutsceneFinished;
        playerInputManager.IsControllable = false;


        door.IsBlocked = true;
        doorEmissiveColorChanger.DisabledColor();

        pressurePad.IsBlocked = true;
        padEmissiveColorChanger.DisabledColor();
    }

    private void OnDestroy()
    {
        playableDirector.stopped -= OnStartCutsceneFinished;
    }

    public void OnKeyCollected()
    {
        door.IsBlocked = false;
        doorEmissiveColorChanger.EnabledColor();

        pressurePad.IsBlocked = false;
        padEmissiveColorChanger.EnabledColor();
    }
    public void OnPadActivated()
    {
        door.Open();
        playerInputManager.IsControllable = false;
        thirdPersonController.Stop();

        StartCoroutine(TimedPlayerInputRecovery());
    }

    private IEnumerator TimedPlayerInputRecovery()
    {
        yield return new WaitForSeconds(7);
        playerInputManager.IsControllable = true;
    }

    private void OnStartCutsceneFinished(PlayableDirector director)
    {
        if(playableDirector = director)
        {
            audioManager.SnapshotTransitionTo(audioManager.GamePlay, 1);
            playerInputManager.IsControllable = true;
        }
    }

}
