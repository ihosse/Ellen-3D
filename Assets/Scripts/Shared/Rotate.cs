using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotationDirection = Vector3.up;

    [SerializeField]
    private float speed = 1;

    private void Update()
    {
        transform.Rotate(rotationDirection * speed * Time.deltaTime);
    }
}
