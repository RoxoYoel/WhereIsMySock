using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        // Resetear la velocidad a cero
        rb.linearVelocity = Vector2.zero;

        // Aplicar velocidad en la dirección del "frente" del arma, basado en su rotación
        Vector2 direction = transform.right;  // "transform.right" es hacia dónde está apuntando el arma
        rb.linearVelocity = direction * speed;  // Velocidad en esa dirección
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
