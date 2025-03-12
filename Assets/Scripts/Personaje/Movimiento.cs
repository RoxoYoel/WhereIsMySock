using UnityEngine;

public class Movimiento : MonoBehaviour
{
    float move;
    public int speed;
    public int jumpForce;
    public int life;

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
            speed = 8;
        }
        else
        {
            speed = 5;
        }

        //Si pulsa la tecal espacio cambio el bool a true para añadirle la fuerza en el fixedUpdate
        if (Input.GetKeyDown("space") && isGround)
        {

            print("pulsa espacio");
            anim.SetTrigger("Jump");
            anim.SetBool("Ground", false);
            isGround = false;
            Invoke("Jump", 0.1f);
        }

        //Activamos la animacion de andar
        anim.SetFloat("Walk", move);
    }

    void FixedUpdate()
    {
        //Añado fuerza para mover el personaje
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        //Añado la fuerza del salto
        if (jump )
        {
            print("salta");
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

        if (collision.gameObject.CompareTag("Enemy") && invulnerable == false)
        {
            life--;
            invulnerable = true;
            print(life);
            Invoke("Hurt", 0);
        }
    }

    public void Jump()
    {
        jump = true;
    }
}
