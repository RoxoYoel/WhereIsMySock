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
        //rb.linearVelocity = Vector2.zero;

        // Aplicar fuerza relativa en la dirección del transform (hacia adelante)
        //rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
        rb.linearVelocity = transform.right * speed;
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
