using UnityEngine;

namespace Ellen3DFinal
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private Cutscene cutscene;

        private void Start()
        {
            cutscene.Play();
        }
    }
}
