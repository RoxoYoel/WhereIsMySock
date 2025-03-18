using UnityEngine;

public class VidaSystem : MonoBehaviour
{
    public GameManager GameManager;
    Movimiento mov;
    public Animator invul;

    public float pushForce = 2f;
    bool invulnerable;
    //public AudioSource audio;

    Rigidbody2D rb;
    Animator anim;

    public void OnCollisionEnter2D(Collision2D other)
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        mov = GetComponent<Movimiento>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            Debug.Log("Colisión detectada con un enemigo");
            if (!invulnerable)
            {
                Debug.Log("El personaje no es invulnerable, aplicando daño");
                invulnerable = true;
                mov.enabled = false;
                invul.enabled = true;
                anim.SetTrigger("Hurt");
                Invoke("Reactivar", 0.5f);
                Invoke("Hurt", 2.5f);
                GameManager.Chocar();
            }
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
