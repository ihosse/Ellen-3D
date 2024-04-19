using UnityEngine;

public class Collectible : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem effect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject particleEffect = Instantiate(effect.gameObject);
            Destroy(particleEffect,1);

            gameObject.SetActive(false);
        }
    }
}
