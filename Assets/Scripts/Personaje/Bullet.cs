using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    Vector2 negativo = new Vector2(-1,1);
    Vector2 direccion;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Vector2 comp = transform.localScale;
        // Resetear la velocidad a cero
        rb.linearVelocity = Vector2.zero;

        if (comp == negativo)
        {
            direccion = -transform.right;  // "transform.right" es hacia dónde está apuntando el arma
            rb.linearVelocity = direccion * speed;  // Velocidad en esa dirección
        }
        else
        {
            direccion = transform.right;  // "transform.right" es hacia dónde está apuntando el arma
            rb.linearVelocity = direccion * speed;  // Velocidad en esa dirección 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        Ocult();
    }

    private void OnBecameInvisible()
    {
        Ocult();
    }

    private void Ocult()
    {
        gameObject.SetActive(false);
    }
}
