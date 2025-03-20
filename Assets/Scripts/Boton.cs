using UnityEngine;

public class Boton : MonoBehaviour
{
    public Animator animBoton;
    public JumpController jumpController;

    //private bool playerInRange = false;
    public Animator gearAnim;
    void Start()
    {
       // LeverCanvas.SetActive(false);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boton") && jumpController.jumpAttack)
        {
            animBoton.SetBool("Presionado", true);
            gearAnim.Play("GearSpin2");

        }

        if (collision.gameObject.CompareTag("Boton2") && jumpController.jumpAttack)
        {
            animBoton.SetBool("Presionado", true);
            Debug.Log("Palanca activada");
            gearAnim.Play("Gear4");

        }
    }
    void Update()
    {
 
    }
}
