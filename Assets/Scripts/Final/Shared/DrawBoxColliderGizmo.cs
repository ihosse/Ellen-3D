using UnityEngine;

namespace Ellen3DFinal
{
    [RequireComponent(typeof(BoxCollider))]
    public class DrawBoxColliderGizmo : MonoBehaviour
    {
        private BoxCollider boxCollider;

        private void Awake()
        {
            boxCollider = GetComponent<BoxCollider>();
        }

        private void OnDrawGizmos()
        {
            if (boxCollider == null)
                boxCollider = GetComponent<BoxCollider>();

            Gizmos.color = Color.red;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireCube(boxCollider.center, boxCollider.size);
        }
    }
}
