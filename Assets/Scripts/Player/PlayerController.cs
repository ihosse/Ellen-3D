using StarterAssets;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private ThirdPersonController thirdPersonController;
    private PlayerAttack playerAttack;
    private PlayerSound playerSound;

    private void Start()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();  
        playerAttack = GetComponent<PlayerAttack>();
        playerSound = GetComponent<PlayerSound>();
    }

    private void Update()
    {
        //_hasAnimator = TryGetComponent(out _animator);

        thirdPersonController.JumpAndGravity();
        thirdPersonController.GroundedCheck();
        thirdPersonController.Move();
        //Attack();
    }
}
