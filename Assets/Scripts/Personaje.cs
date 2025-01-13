using UnityEngine;

public class Personaje : MonoBehaviour
{
    public int speed;
    public float maxSpeedPos;
    public float maxSpeedNeg;
    public float drag;
    float move;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sp;
    public SpriteRenderer gunFlip;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Cojo el input de la "A" y la "S" y lo guardo en una variable
        move = Input.GetAxis("Horizontal");
        
        //Hago el flip del sprite dependiendo de hacia donde se mueve
        if(move > 0)
        {
            sp.flipX = false;
            gunFlip.flipX = false;
        }
        else if(move < 0)
        {
            sp.flipX= true;
            gunFlip.flipX = true;
        }

        //Limito la velocidad maxima tanto en positivo como en negativo
        if (rb.linearVelocityX > maxSpeedPos)
        {
            rb.linearVelocityX = maxSpeedPos;
        }
        if (rb.linearVelocityX < maxSpeedNeg)
        {
            rb.linearVelocityX = maxSpeedNeg;
        }
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Cambio el bool para saber cuando esta tocando el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded= false;
        }
    }

    void FixedUpdate()
    {
        //Añado fuerza para mover el personaje
        if (move!=0)
        {
            rb.AddForce(Vector2.right * move * speed);
        }

        //Activar la animacion de correr y desactivarla si no esta tocando el suelo
        if (move != 0 && isGrounded == true)
        {
            print("Activar animacion andar");
            anim.SetBool("Walk", true);
        }
        else
        {
            print("Desactivar animacion andar, activar reposo");
            anim.SetBool("Walk", false);
        }

        //Cuando dejas de pulsar las teclas "A" y "S", cambio la velocidad para que frene antes
        if (move == 0 && isGrounded == true)
        {
            Vector2 velocity = rb.linearVelocity;
            velocity.x = Mathf.Lerp(velocity.x, 0, drag * Time.fixedDeltaTime);
            rb.linearVelocity = velocity;
        }
    }
}
