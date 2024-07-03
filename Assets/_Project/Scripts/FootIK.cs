using UnityEngine;

public class FootIK : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Transform leftFootTarget;

    [SerializeField]
    private Transform rightFootTarget;

    [SerializeField]
    private Transform leftFootHint;

    [SerializeField]
    private Transform rightFootHint;

    void OnAnimatorIK(int layerIndex)
    {
        if (animator)
        {
            // Left Foot
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
            animator.SetIKHintPositionWeight(AvatarIKHint.LeftKnee, 1);

            RaycastHit hit;
            if (Physics.Raycast(leftFootTarget.position + Vector3.up, Vector3.down, out hit, 1.5f))
            {
                leftFootTarget.position = hit.point + Vector3.up * .1f;
                leftFootTarget.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, hit.normal), hit.normal);
            }

            animator.SetIKPosition(AvatarIKGoal.LeftFoot, leftFootTarget.position);
            animator.SetIKRotation(AvatarIKGoal.LeftFoot, leftFootTarget.rotation);
            animator.SetIKHintPosition(AvatarIKHint.LeftKnee, leftFootHint.position);

            // Right Foot
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
            animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1);
            animator.SetIKHintPositionWeight(AvatarIKHint.RightKnee, 1);

            if (Physics.Raycast(rightFootTarget.position + Vector3.up, Vector3.down, out hit, 1.5f))
            {
                rightFootTarget.position = hit.point + Vector3.up * .1f;
                rightFootTarget.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, hit.normal), hit.normal);
            }

            animator.SetIKPosition(AvatarIKGoal.RightFoot, rightFootTarget.position);
            animator.SetIKRotation(AvatarIKGoal.RightFoot, rightFootTarget.rotation);
            animator.SetIKHintPosition(AvatarIKHint.RightKnee, rightFootHint.position);
        }
    }
}
