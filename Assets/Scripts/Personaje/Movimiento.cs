using UnityEngine;

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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //Cojo el input de la "A" y la "S" y lo guardo en una variable
        move = Input.GetAxis("Horizontal");

        //Hago el flip del sprite dependiendo de hacia donde se mueve
        if (move > 0)
        {
            sp.flipX = false;
            gunFlip.flipX = false;
        }
        else if (move < 0)
        {
            sp.flipX = true;
            gunFlip.flipX = true;
        }

        //Cambio la velocidad para que corra al pulsar shift
        if (Input.GetKey(KeyCode.LeftShift) && isGround)
        {
            speed = 6;
            anim.SetFloat("Walk", 2);
        }
        else
        {
            speed = 4;
            //Activamos la animacion de andar
            anim.SetFloat("Walk", move);
        }

        //Si pulsa la tecal espacio cambio el bool a true para añadirle la fuerza en el fixedUpdate
        if (Input.GetKeyDown("space") && isGround)
        {
            anim.SetTrigger("Jump");
            anim.SetBool("Ground", false);
            isGround = false;
            jump = true;
        }
    }

    void FixedUpdate()
    {
        //Añado fuerza para mover el personaje
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        //Añado la fuerza del salto
        if (jump )
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Cambio el bool para saber cuando esta tocando el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            anim.SetBool("Ground", true);
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
