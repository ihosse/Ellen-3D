using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineImpulseSource))]
public class CameraImpulse : MonoBehaviour
{
    private CinemachineImpulseSource source;

    void Start()
    {
        source = GetComponent<CinemachineImpulseSource>();
    }

    public void ApplyImpulse()
    {
        source.GenerateImpulse();
    }
}
