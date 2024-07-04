using UnityEngine;using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
}
