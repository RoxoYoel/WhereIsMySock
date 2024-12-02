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
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal");
        
        if(move > 0)
        {
            sp.flipX = false;
        }
        else if(move < 0)
        {
            sp.flipX= true;
        }

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
        if (move!=0)
        {
            rb.AddForce(Vector2.right * move * speed);
        }
        if (move != 0 && isGrounded == true)
        {
            print("Activar animacion correr");
            //anim.SetBool("Run", true);
        }
        else
        {
            print("Desactivar animacion correr, activar reposo");
            //anim.SetBool("Run", false);
        }


        if (move == 0 && isGrounded == true)
        {
            Vector2 velocity = rb.linearVelocity;
            velocity.x = Mathf.Lerp(velocity.x, 0, drag * Time.fixedDeltaTime);
            rb.linearVelocity = velocity;
        }
    }
}
