using Cinemachine;
using UnityEngine;

public class ChangePriorityCamera : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera topPriorityCamera;
    public void Change()
    {
        topPriorityCamera.MoveToTopOfPrioritySubqueue();
    }
}
