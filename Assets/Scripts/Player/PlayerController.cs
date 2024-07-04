using StarterAssets;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool HasStaff { get { return playerAttack.Staff.activeSelf; } }

    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInput;
    private PlayerAttack playerAttack;
    private PlayerSound playerSound;
    private PlayerAnimations playerAnimations;

    private bool _disableMovement;


    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInput = GetComponent<StarterAssetsInputs>();
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

    public void OnStaffCollected()
    {
        playerAttack.EnableStaff();
    }

    public void DisableAttack(bool disable)
    {
        if (HasStaff == false)
            return;

        if (playerAttack == null)
            playerAttack = GetComponent<PlayerAttack>();

        playerAttack.CanAttack = !disable;
    }

    public void DisableMovementControl(bool disable)
    {
        if (thirdPersonController == null)
            thirdPersonController = GetComponent<ThirdPersonController>();

        thirdPersonController.DisableMovementControl(disable);
    }
}
