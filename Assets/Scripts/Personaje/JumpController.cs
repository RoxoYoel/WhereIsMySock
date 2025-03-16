using UnityEngine;

public class JumpController : MonoBehaviour
{
    public int jumpForce;
    public bool isGround;

    private bool jump = false;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();  // Referencia al Animator
    }

    void Update()
    {
        // Salto
        if (Input.GetKeyDown("space") && isGround)
        {
            anim.SetTrigger("Jump");
            jump = true; // Se procesa en FixedUpdate()
        }
    }

    void FixedUpdate()
    {
        // Salto
        if (jump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGround = false; // Se desactiva solo después de aplicar la fuerza
            jump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detecta cuando toca el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            anim.SetBool("Ground", true);  // Actualiza el booleano en el Animator
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
            anim.SetBool("Ground", false);  // Actualiza el booleano en el Animator
        }
    }
}
