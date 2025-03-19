using UnityEngine;

public class EnemyVidaSystem : MonoBehaviour
{
    public GameManager GameManager;
    Move mov;
    public Animator invul;

    public float pushForce = 2f;
    bool invulnerable;
    //public AudioSource audio;

    Rigidbody2D rb;
    Animator anim;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        mov = GetComponent<Move>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Death") && !invulnerable)
        {
            invulnerable = true;
            mov.enabled = false;
            invul.enabled = true;
            anim.SetTrigger("Hurt");
            Invoke("Reactivar", 0.5f);
            Invoke("Hurt", 2.5f);
            GameManager.Chocar();
        }

        if (collision.gameObject.CompareTag("Death") && invulnerable)
        {
            // Aplicar una fuerza en la dirección opuesta al obstáculo
            Vector2 pushDirection = (transform.position - collision.transform.position).normalized;
            rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Death") && !invulnerable)
        {
            invulnerable = true;
            mov.enabled = false;
            invul.enabled = true;
            anim.SetTrigger("Hurt");
            Invoke("Reactivar", 0.5f);
            Invoke("Hurt", 2.5f);
            GameManager.Chocar();
        }
    }

    public void Reactivar()
    {
        mov.enabled = true;
    }

    public void Hurt()
    {
        invulnerable = false;
        invul.enabled = false;
    }
}
