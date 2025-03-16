using UnityEngine;

public class Move : MonoBehaviour
{
    public float move;
    public int speed;

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sp;
    public SpriteRenderer gunFlip;
    public GameObject bulletPoll;
    private JumpController jumpController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();

        jumpController = GetComponent<JumpController>(); // Se obtiene la referencia al script de salto
    }

    private void Update()
    {
        // Obtiene el input antes de actualizar animaciones
        move = Input.GetAxis("Horizontal");

        // Cambio de velocidad al pulsar shift
        if (Input.GetKey(KeyCode.LeftShift) && jumpController.isGround) // Usamos isGround del JumpController
        {
            speed = 6;
            anim.SetFloat("Walk", 2);
        }
        else
        {
            speed = 4;
            anim.SetFloat("Walk", Mathf.Abs(move)); // Usamos Abs para evitar valores negativos en la animaci�n
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
    }

    void FixedUpdate()
    {
        // Movimiento horizontal
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);
    }
}

