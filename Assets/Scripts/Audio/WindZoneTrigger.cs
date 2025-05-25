using UnityEngine;

public class WindZoneTrigger : MonoBehaviour
{
    private AudioSource windAudio;

    private void Start()
    {
        windAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            windAudio.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            windAudio.Stop();
        }
    }
}
