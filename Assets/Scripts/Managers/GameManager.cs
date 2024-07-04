using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Cutscene cutscene;

    private void Start()
    {
        cutscene.Play();
    }
}
