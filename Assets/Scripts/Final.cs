using UnityEngine;

public class Final : MonoBehaviour
{
    public GameManager GameManager;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            GameManager.CompleteLevel();
        }
    }
}
