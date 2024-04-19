using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    public UnityEvent OnStartOpen;
    public UnityEvent OnFinishOpenning;

    [SerializeField]
    private float timeToFinish = 1;

    private Animator animator;
    private bool isOpen;


    private void Start()
    {
        animator = GetComponent<Animator>();
        isOpen = false;
    }

    public void Open()
    {
        if (isOpen)
            return;

        isOpen = true;
        animator.SetTrigger("Open");
        OnStartOpen?.Invoke();
        Invoke("Close", timeToFinish);
    }

    public void Close()
    {
        OnFinishOpenning?.Invoke();
    }
}
