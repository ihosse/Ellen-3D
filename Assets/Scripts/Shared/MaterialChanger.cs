using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class MaterialChanger : MonoBehaviour
{
    [SerializeField]
    private Material disabledMaterial;

    [SerializeField]
    private Material enabledMaterial;

    private new Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }
    public void ChangeToDisabledMaterial()
    {
        renderer.material = disabledMaterial;
    }

    public void ChangeToEnabledMaterial()
    {
        renderer.material = enabledMaterial;
    }

}
