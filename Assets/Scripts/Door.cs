using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(Animator), typeof(AudioSource))]
[RequireComponent(typeof(MaterialChanger))]
public class Door : MonoBehaviour
{
    [field: SerializeField]
    public bool IsLocked { get; private set; }

    [SerializeField]
    private float openDelay = 1;

    [SerializeField]
    private float timeToEnablePlayer   = 1;

    [SerializeField]
    private AudioManager audioManager;

    [SerializeField]
    private PlayerController playerController;

    [Header("On Start Open")]
    [SerializeField]
    private ParticleSystem particle;

    [SerializeField]
    private CinemachineVirtualCamera openPriorityCamera;

    [SerializeField]
    private AudioMixerSnapshot openSnapshot;

    [SerializeField]
    private AudioClip audioFx;

    [Header("On Finish Opening")]
    [SerializeField]
    private CinemachineVirtualCamera closePriorityCamera;

    private Animator animator;
    private AudioSource audioSource;
    private MaterialChanger materialChanger;

    private bool isOpen;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        materialChanger = GetComponent<MaterialChanger>();  

        isOpen = false;
        materialChanger.ChangeToDisabledMaterial();
    }

    public void Unlock()
    {
        IsLocked = false;
        materialChanger.ChangeToEnabledMaterial();
    }

    public void Open()
    {
        if (isOpen || IsLocked)
            return;

        StartCoroutine(OpenSequence());
    }

    private IEnumerator OpenSequence()
    {
        playerController.DisableMovementControl(true);
        playerController.DisableAttack(true);

        if(openPriorityCamera != null)
            openPriorityCamera.MoveToTopOfPrioritySubqueue();

        yield return new WaitForSeconds(openDelay);

        if(particle != null)
            particle.Play();

        if (audioManager != null)
            audioManager.SnapshotTransitionTo(audioManager.Exploration, 1);

        if (audioFx != null)
            audioSource.PlayOneShot(audioFx);

        animator.SetTrigger("Open");

        isOpen = true; 

        Invoke(nameof(Close), timeToEnablePlayer);
    }

    public void Close()
    {
        if(closePriorityCamera != null)
            closePriorityCamera.MoveToTopOfPrioritySubqueue();

        playerController.DisableMovementControl(false);
        playerController.DisableAttack(false);
    }
}