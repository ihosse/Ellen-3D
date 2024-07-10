using Cinemachine;
using UnityEngine;

namespace Ellen3DFinal
{
    public class ChangePriorityCamera : MonoBehaviour
    {
        [SerializeField]
        private CinemachineVirtualCamera topPriorityCamera;
        public void Change()
        {
            topPriorityCamera.MoveToTopOfPrioritySubqueue();
        }
    }
}
