using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector2 puntoRespawn;

    void Start()
    {
        puntoRespawn = transform.position;
    }

public void ActualizarCheckpoint(Vector2 nuevaPosicion)
{
    Debug.Log("Checkpoint guardado en: " + nuevaPosicion);
    puntoRespawn = nuevaPosicion;
}

    public void ReiniciarPosicion()
    {
        Debug.Log("Jugador reapareciendo en: " + puntoRespawn);
        transform.position = puntoRespawn;
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Death")) 
        {
            Debug.Log("Jugador cayó en la zona de muerte");
            ReiniciarPosicion();
        }
    }
}
