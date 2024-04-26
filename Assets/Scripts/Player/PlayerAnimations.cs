using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    public Animator Animator { get; private set; }

    // animation IDs
    public int AnimIDSpeed { get; private set; }
    public int AnimIDGrounded { get; private set; }
    public int AnimIDJump { get; private set; }
    public int AnimIDFreeFall { get; private set; }
    public int AnimIDMotionSpeed { get; private set; }
    public int AnimIDHit { get; private set; }
    public int AnimIDAttack { get; private set; }

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        AssignAnimationIDs();
    }

    private void AssignAnimationIDs()
    {
        AnimIDSpeed = Animator.StringToHash("Speed");
        AnimIDGrounded = Animator.StringToHash("Grounded");
        AnimIDJump = Animator.StringToHash("Jump");
        AnimIDFreeFall = Animator.StringToHash("FreeFall");
        AnimIDMotionSpeed = Animator.StringToHash("MotionSpeed");
        AnimIDHit = Animator.StringToHash("Hit");
        AnimIDAttack = Animator.StringToHash("Attack");
    }
}
