using StarterAssets;
using UnityEngine;

namespace Ellen3DFinal
{
    public class PlayerController : MonoBehaviour
    {
        public bool HasStaff { get { return playerAttack.Staff.activeSelf; } }

        private ThirdPersonController thirdPersonController;
        private PlayerAttack playerAttack;
        private PlayerAnimations playerAnimations;

        private void Awake()
        {
            thirdPersonController = GetComponent<ThirdPersonController>();
            playerAttack = GetComponent<PlayerAttack>();
            playerAnimations = GetComponent<PlayerAnimations>();

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
}