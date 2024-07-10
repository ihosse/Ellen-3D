using UnityEngine;
using UnityEngine.Events;

namespace Ellen3DFinal {

    [RequireComponent(typeof(Collider))]
    public class TriggerEvent : MonoBehaviour
    {
        public UnityEvent OnTrigger;

        [SerializeField]
        private string colliderTag;

        [SerializeField]
        private CameraImpulse cameraImpulseEffect;

        [SerializeField]
        private bool isOneTimeUse = true;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(colliderTag))
            {
                OnTrigger?.Invoke();

                if (cameraImpulseEffect != null) cameraImpulseEffect.ApplyImpulse();

                if (isOneTimeUse)
                    GetComponent<Collider>().enabled = false;
            }
        }
    }
}
