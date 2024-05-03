using UnityEngine;
using UnityEngine.Events;

public class Collectible : MonoBehaviour
{
    public UnityEvent OnCollect;

    [SerializeField]
    private ParticleSystem effect;

    [SerializeField]
    private AudioClip audioClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject particleEffect = Instantiate(effect.gameObject);
            particleEffect.transform.position = transform.position;
            Destroy(particleEffect,1);

            OnCollect?.Invoke();

            if(audioClip != null)
                AudioSource.PlayClipAtPoint(audioClip, transform.position);

            gameObject.SetActive(false);
        }
    }
}
