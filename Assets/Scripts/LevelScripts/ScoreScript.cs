using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    public GameManager gameManager;  // Referencia al GameManager
    public CanvasUI canvasUI;       // Referencia al script CanvasUI que controla la UI de vidas

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Aumentar vidas solo si no están al máximo (ejemplo: máximo 3)
            if (GameManager.lives < 3)
            {
                GameManager.lives++;
                Debug.Log("¡Vida recuperada! Vidas: " + GameManager.lives);

                // Actualizar la UI de vidas
                if (canvasUI != null)
                {
                    canvasUI.setActiveSprite(GameManager.lives);
                }
            }

            Destroy(gameObject);
        }
    }
}
