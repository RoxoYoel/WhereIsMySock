using UnityEngine;

public class Boton : MonoBehaviour
{
    public Animator animBoton;
    public JumpController jumpController;
    void Start()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boton") && jumpController.jumpAttack)
        {
            animBoton.SetBool("Presionado", true);
        }
    }
    void Update()
    {
        
    }
}
