using StarterAssets;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private PlayerAnimations _playerAnimations;
    private StarterAssetsInputs _playerInput;
    private ThirdPersonController _thirdPersonController;

    private bool isAttacking;
    private bool _hasAnimator;

    public void Initialize(PlayerAnimations animations, ThirdPersonController thirdPerson)
    {
        if (animations != null)
        {
            _playerAnimations = animations;
            _hasAnimator = true;
        }
        else
        {
            _hasAnimator = false;
        }

        _playerInput = GetComponent<StarterAssetsInputs>();

        _playerAnimations = animations;
        _thirdPersonController = thirdPerson;
    }
    public void Attack()
    {
        if (_playerInput.attack && !isAttacking)
        {
            if (_hasAnimator)
            {
                _playerAnimations.Animator.SetBool(_playerAnimations.AnimIDAttack, true);
            }

            isAttacking = true;
            _thirdPersonController.DisableMovementControl(true);

            StartCoroutine(WaitToAttackAnimationEnd());
        }
    }
    private IEnumerator WaitToAttackAnimationEnd()
    {
        yield return new WaitForSeconds(1);
        isAttacking = false;
        _thirdPersonController.DisableMovementControl(false);
    }

    public void MeleeAttackStart() { }
    public void MeleeAttackEnd()
    {
        _playerAnimations.Animator.SetBool(_playerAnimations.AnimIDAttack, false);

        _playerInput.attack = false;
    }
}
