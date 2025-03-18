using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRespawn respawn = other.GetComponent<PlayerRespawn>();
            if (respawn != null)
            {
                Debug.Log("Checkpoint activado en: " + transform.position);
                respawn.ActualizarCheckpoint(transform.position);
            }
        }
    }
}
