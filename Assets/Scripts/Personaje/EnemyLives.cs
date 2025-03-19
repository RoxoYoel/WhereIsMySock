using UnityEngine;

public class EnemyLives : MonoBehaviour
{
    public GameManager GameManager;
    public GameObject enemigo;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.VidasEnemigo();
            enemigo.SetActive(false);
        }
    }

}
