using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Ellen3DFinal
{
    [RequireComponent(typeof(Collider))]
    public class Damager : MonoBehaviour
    {
        [SerializeField]
        private bool applyCameraImpulseWhenHitSomething;

        [SerializeField]
        private CameraImpulse cameraImpulse;

        public UnityEvent OnHitSomething;
        public UnityEvent OnHitTarget;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Damageable>(out Damageable damageable))
            {
                damageable.Hit();
                OnHitTarget?.Invoke();
            }
            else
            {
                OnHitSomething?.Invoke();
                if (applyCameraImpulseWhenHitSomething)
                    StartCoroutine(ApplyCameraImpulse());
            }
        }

        private IEnumerator ApplyCameraImpulse()
        {

            yield return new WaitForSeconds(.2f);
            if (cameraImpulse != null)
                cameraImpulse.ApplyImpulse();
        }
    }
}
