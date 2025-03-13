using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public GameObject LeverCanvas;
    private bool playerInRange = false;
    public Animator gearAnim;
    public GameObject leverPart; 

    public void Start()
    {
        LeverCanvas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            LeverCanvas.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            LeverCanvas.SetActive(false); 
            
        }
    }
    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Palanca activada");
            gearAnim.Play("GearSpin2");
            leverPart.transform.rotation = Quaternion.Euler(0, 0, -70);
        }
    }
}
