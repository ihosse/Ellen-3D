using System.Collections;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
    {
        [SerializeField]
        private bool isControllable;

        [Header("Character Input Values")]
        public Vector2 move;
        public Vector2 look;
        public bool jump;
        public bool sprint;
        public bool attack;

        [Header("Movement Settings")]
        public bool analogMovement;

        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
        public void OnMove(InputValue value)
        {
            MoveInput(value.Get<Vector2>());
        }

        public void OnLook(InputValue value)
        {
            if (cursorInputForLook)
            {
                LookInput(value.Get<Vector2>());
            }
        }

        public void OnJump(InputValue value)
        {
            JumpInput(value.isPressed);
        }
        public void OnAttack(InputValue value)
        {
            AttackInput(value.isPressed);
        }

        public void OnSprint(InputValue value)
        {
            SprintInput(value.isPressed);
        }
#endif

        public void EnableMovement(bool canMove)
        {
            if (canMove)
            {
                isControllable = true;
            }
            else
            {
                isControllable = false;
                move = Vector2.zero;
            }
        }

        public void StopMovementForSeconds(float seconds)
        {
            EnableMovement(false);
            StartCoroutine(WaitAndEnableMovement(seconds));
        }

        private IEnumerator WaitAndEnableMovement(float seconds)
        {
            yield return new WaitForSecondsRealtime(.15f);
            Time.timeScale = 0f;
            yield return new WaitForSecondsRealtime(.25f);
            Time.timeScale = 1f;
            yield return new WaitForSecondsRealtime(seconds);
            EnableMovement(true);
        }

        public void MoveInput(Vector2 newMoveDirection)
        {
            if (!isControllable)
            {
                move = Vector2.zero;
                return;
            }

            move = newMoveDirection;
        }

        public void LookInput(Vector2 newLookDirection)
        {
            if (!isControllable)
                return;

            look = newLookDirection;
        }

        public void JumpInput(bool newJumpState)
        {
            if (!isControllable)
                return;

            jump = newJumpState;
        }

        public void AttackInput(bool newAttackState)
        {
            attack = newAttackState;
        }

        public void SprintInput(bool newSprintState)
        {
            if (!isControllable)
                return;

            sprint = newSprintState;
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }

}