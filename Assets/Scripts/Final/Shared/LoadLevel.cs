using UnityEngine;using UnityEngine.SceneManagement;

namespace Ellen3DFinal
{
    public class LoadLevel : MonoBehaviour
    {
        public void Reload()
        {
            SceneManager.LoadScene(0);
        }
    }
}