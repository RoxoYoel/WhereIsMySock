using Unity.VisualScripting;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public int jumpForce;
    public int jumpAttackForce;
    private bool jump = false;
    private Rigidbody2D rb;
    private Animator anim;
    public PhysicsMaterial2D materialRebote;
    public PhysicsMaterial2D materialNoFriction;
    public GameObject EnemigoColliderRebote;

    [Header("Ground Check")]
    public float groundCheckDistance = 0.1f;
    public LayerMask groundLayer;
    public Vector2 groundCheckOffsetFront;
    public Vector2 groundCheckOffsetBack;

    public bool isGround;
    public bool jumpAttack;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.sharedMaterial = materialNoFriction;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        JumpAttack();

        // Salto normal
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            anim.SetTrigger("Jump");
            jump = true;
        }
    }

    void FixedUpdate()
    {
        // Verificar si está en el suelo con los Raycasts
        isGround = CheckGround();

        if (jump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGround = false;
            jump = false;
        }

        // Si toca el suelo, reseteamos JumpAttack y cambiamos el material
        if (isGround)
        {
            
            Invoke("CambiarMaterial", 0.1f);
            anim.SetBool("Ground", true);
            EnemigoColliderRebote.SetActive(false);
        }
        else
        {
            anim.SetBool("Ground", false);
        }
    }

    bool CheckGround()
    {
        Vector2 originFront = (Vector2)transform.position + groundCheckOffsetFront;
        Vector2 originBack = (Vector2)transform.position + groundCheckOffsetBack;

        RaycastHit2D hitFront = Physics2D.Raycast(originFront, Vector2.down, groundCheckDistance, groundLayer);
        RaycastHit2D hitBack = Physics2D.Raycast(originBack, Vector2.down, groundCheckDistance, groundLayer);

        Debug.DrawRay(originFront, Vector2.down * groundCheckDistance, hitFront.collider ? Color.green : Color.red);
        Debug.DrawRay(originBack, Vector2.down * groundCheckDistance, hitBack.collider ? Color.green : Color.red);

        return hitFront.collider != null || hitBack.collider != null;
    }

    public void JumpAttack()
    {
        // Si está en el aire, pulsa "S" y aún no ha hecho el ataque
        if (!isGround && Input.GetKeyDown(KeyCode.S) && !jumpAttack)
        {
            rb.linearVelocity = Vector2.zero; // Resetea la velocidad para evitar inconsistencias
            rb.AddForce(Vector2.down * jumpAttackForce, ForceMode2D.Impulse);
            jumpAttack = true;
            anim.SetTrigger("GroundPound");

            // Cambia el material para que rebote
            rb.sharedMaterial = materialRebote;
            EnemigoColliderRebote.SetActive(true);
        }
    }

    public void CambiarMaterial()
    {
        rb.sharedMaterial = materialNoFriction;
        jumpAttack = false;
    }
}