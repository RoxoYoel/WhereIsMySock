using UnityEngine;

public class Boton : MonoBehaviour
{
    public Animator animBoton;
    public Animator animBoton2;
    public JumpController jumpController;

    //private bool playerInRange = false;
    public Animator gearAnim;
    public Animator gearAnim2;
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
            animBoton2.SetBool("Presionado", true);
            Debug.Log("Palanca activada");
            gearAnim2.Play("GearSpin2");

        }
    }
    void Update()
    {
 
    }
}
