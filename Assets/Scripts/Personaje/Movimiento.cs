using UnityEngine;
using UnityEngine.Diagnostics;

public class Movimiento : MonoBehaviour
{
    float move;
    public int speed;
    public int jumpForce;

    bool isGround;
    bool jump = false;
    bool invulnerable = false;

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sp;
    public SpriteRenderer gunFlip;
    public GameObject bulletPoll;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Obtiene el input antes de actualizar animaciones
        move = Input.GetAxis("Horizontal");

        // Cambio de velocidad al pulsar shift
        if (Input.GetKey(KeyCode.LeftShift) && isGround)
        {
            speed = 6;
            anim.SetFloat("Walk", 2);
        }
        else
        {
            speed = 4;
            anim.SetFloat("Walk", Mathf.Abs(move)); // Usamos Abs para evitar valores negativos en la animación
        }

        // Flip del sprite
        if (move > 0)
        {
            sp.flipX = false;
            gunFlip.flipX = false;
            bulletPoll.transform.localPosition = new Vector2(1, 0);
            bulletPoll.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (move < 0)
        {
            sp.flipX = true;
            gunFlip.flipX = true;
            bulletPoll.transform.localPosition = new Vector2(-1, 0);
            bulletPoll.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        // Salto
        if (Input.GetKeyDown("space") && isGround)
        {
            anim.SetTrigger("Jump");
            anim.SetBool("Ground", false);
            jump = true; // Se procesa en FixedUpdate()
        }
    }

    void FixedUpdate()
    {
        // Movimiento
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

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
            anim.SetBool("Ground", true);
            CancelInvoke("InAir"); // Cancelamos el Invoke que podría desactivar isGround antes de tiempo
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Invoke("InAir", 0.1f);
        }
    }

    public void InAir()
    {
        isGround = false;
    }
}
