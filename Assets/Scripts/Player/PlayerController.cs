using StarterAssets;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private ThirdPersonController thirdPersonController;
    private PlayerAttack playerAttack;
    private PlayerSound playerSound;
    private PlayerAnimations playerAnimations;

    private void Start()
    {

        thirdPersonController = GetComponent<ThirdPersonController>();
        playerAttack = GetComponent<PlayerAttack>();
        playerAnimations  = GetComponent<PlayerAnimations>();
        playerSound = GetComponent<PlayerSound>();

        playerAttack.Initialize(playerAnimations, thirdPersonController);
        thirdPersonController.Initialize(playerAnimations);
    }

    private void Update()
    {
        thirdPersonController.JumpAndGravity();
        thirdPersonController.GroundedCheck();
        thirdPersonController.Move();
        playerAttack.Attack();
    }
}
