using StarterAssets;
using System.Collections;
using UnityEngine;

namespace Ellen3DFinal
{
    public class PlayerAttack : MonoBehaviour
    {
        public GameObject Staff;

        public bool CanAttack { get; set; }

        [SerializeField]
        private bool startWithStaff = false;

        [SerializeField]
        private Collider hitBox;

        private PlayerAnimations _playerAnimations;
        private StarterAssetsInputs _playerInput;
        private ThirdPersonController _thirdPersonController;

        private bool isAttacking;
        private int attackNumber;
        private bool _hasAnimator;

        private void Start()
        {
            hitBox.enabled = false;

            if (Staff != null)
                Staff.SetActive(false);
            else
                Debug.LogError("Variable staff has not been assigned");

            if (startWithStaff)
                EnableStaff();
        }
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

        public void EnableStaff()
        {
            if (Staff == null)
                return;

            Staff.SetActive(true);
            CanAttack = true;
            hitBox.enabled = false;
        }

        public void Attack()
        {
            if (!CanAttack || isAttacking)
                return;


            if (_playerInput.attack)
            {
                if (_hasAnimator)
                {
                    attackNumber = Random.Range(2, 5);
                    _playerAnimations.Animator.SetInteger(_playerAnimations.AnimIDAttack, attackNumber);
                }
                isAttacking = true;
                _thirdPersonController.DisableMovementControl(true);

                StartCoroutine(WaitToAttackAnimationEnd());
            }
        }

        private IEnumerator WaitToAttackAnimationEnd()
        {
            yield return new WaitForSeconds(.2f);
            hitBox.enabled = true;

            yield return new WaitForSeconds(.3f);
            //0 create transition to movement Blend Tree
            _playerAnimations.Animator.SetInteger(_playerAnimations.AnimIDAttack, 0);


            yield return new WaitForSeconds(.1f);
            _playerInput.attack = false;
            isAttacking = false;
            hitBox.enabled = false;


            if(CanAttack)
                _thirdPersonController.DisableMovementControl(false);
        }

        public void MeleeAttackStart()
        {
            hitBox.enabled = true;
        }
        public void MeleeAttackEnd()
        {
            hitBox.enabled = false;
        }
    }
}
