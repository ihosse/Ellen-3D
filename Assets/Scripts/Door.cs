using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    public UnityEvent OnStartOpen;
    public UnityEvent OnFinishOpenning;

    public bool IsBlocked {  get; set; }

    [SerializeField]
    private float timeToFinish = 1;

    private Animator animator;
    private bool isOpen;

    private void Start()
    {
        animator = GetComponent<Animator>();
        isOpen = false;
        IsBlocked = true;
    }

    public void Open()
    {
        if (isOpen || IsBlocked)
            return;

        isOpen = true;
        animator.SetTrigger("Open");

        OnStartOpen?.Invoke();
        Invoke(nameof(Close), timeToFinish);
    }

    public void Close()
    {
        OnFinishOpenning?.Invoke();
    }
}
