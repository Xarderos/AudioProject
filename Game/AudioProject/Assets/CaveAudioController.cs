using UnityEngine;

public class CaveAudioController : MonoBehaviour
{
    public AudioSource ambientSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            ambientSound.volume = 0f; 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            ambientSound.volume = 1.0f;
        }
    }
}
