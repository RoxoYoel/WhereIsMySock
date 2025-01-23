using UnityEngine;

public class Items : MonoBehaviour
{
    public GameObject gun;
    //public Shoot shoot;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gun"))
        {
            gun.SetActive(true);
            collision.gameObject.SetActive(false);
            //shoot.enabled = true;
        }
    }
}
