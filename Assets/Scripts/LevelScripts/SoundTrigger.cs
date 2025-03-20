using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioSource audioSource; // Arrastra el AudioSource desde el Inspector

    public void PlayAudio() // Método llamado por el Animation Event
    {
        if (audioSource != null)
        {
            audioSource.enabled = true;
            Invoke("Desactivar", 2f);
        }
    }

    public void Desactivar()
    {
        audioSource.enabled = false;
    }
}
