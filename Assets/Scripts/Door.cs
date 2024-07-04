using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(Animator), typeof(AudioSource))]
public class Door : MonoBehaviour, IOpenable
{
    [field: SerializeField]
    public bool IsLocked { get; set; }

    [SerializeField]
    private float openDelay = 1;

    [SerializeField]
    private float timeToFinish = 1;

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
    private bool isOpen;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        isOpen = false;
        IsLocked = false;
    }

    public void Open(IOpener key)
    {
        //if (key.GetDoor() != this.gameObject)
        //    return;

        //if (isOpen || IsLocked)
        //    return;

        IsLocked = false;
        isOpen = true;

        StartCoroutine(OpenSequence());
    }

    private IEnumerator OpenSequence()
    {
        particle.Play();

        audioManager.SnapshotTransitionTo(audioManager.Exploration, 1);

        playerController.DisableMovementControl(true);
        playerController.DisableAttack(true);

        openPriorityCamera.MoveToTopOfPrioritySubqueue();

        yield return new WaitForSeconds(openDelay);

        animator.SetTrigger("Open");
        audioSource.PlayOneShot(audioFx);

        Invoke(nameof(Close), timeToFinish);
    }

    public void Close()
    {
        closePriorityCamera.MoveToTopOfPrioritySubqueue();
    }
}
