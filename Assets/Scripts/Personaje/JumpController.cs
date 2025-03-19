using Unity.VisualScripting;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public int jumpForce;
    public bool isGround;
    public int jumpAttackForce;
    private bool jumpAttack;
    private bool jump = false;
    private Rigidbody2D rb;
    private Animator anim;
    public PhysicsMaterial2D materialRebote;
    public PhysicsMaterial2D materialNoFriction;
    private bool materialReboteActivado;
    public GameObject EnemigoColliderRebote;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.sharedMaterial = materialNoFriction;
        anim = GetComponent<Animator>();  // Referencia al Animator
    }

    public void JumpAttack()
    {
        if (isGround == false && Input.GetKey(KeyCode.S) && jumpAttack == false)
        {
            rb.AddForce(Vector2.down *  jumpAttackForce, ForceMode2D.Impulse);
            jumpAttack = true;
            anim.SetTrigger("GroundPound");
            materialReboteActivado = true;
            EnemigoColliderRebote.SetActive(true);
        }
    }

    public void CambiarMaterial()
    {
        if (materialReboteActivado == false)
        {
            rb.sharedMaterial = materialNoFriction;
        }
        else if (materialReboteActivado)
        {
            rb.sharedMaterial = materialRebote;
        }

    }

    void Update()
    {
        CambiarMaterial();
        JumpAttack();
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
            materialReboteActivado = false;
            EnemigoColliderRebote.SetActive(false);

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpAttack = false;
            isGround = false;
            anim.SetBool("Ground", false);  // Actualiza el booleano en el Animator
        }
    }
}
