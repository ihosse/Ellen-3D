using UnityEngine;

[RequireComponent(typeof(Material))]
public class EmissiveColorChanger : MonoBehaviour
{
    [SerializeField]
    private Color disabledColor;

    [SerializeField]
    private Color enabledColor;

    [SerializeField]
    private Material material;

    public void DisabledColor()
    {
        material.SetColor("_EmissionColor", disabledColor);
    }

    public void EnabledColor()
    {
        material.SetColor("_EmissionColor", enabledColor);
    }

}
