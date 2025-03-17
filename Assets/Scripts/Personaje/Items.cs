using UnityEngine;

public class Items : MonoBehaviour
{
    public GameObject gun;
    public int bulletCount = 0; // Contador de balas

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gun"))
        {
            gun.SetActive(true);
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Bala"))
        {
            // Desactivar el objeto inmediatamente para evitar doble detección
            collision.gameObject.SetActive(false);

            // Obtener el componente "BalaPickup" para saber cuántas balas dar
            BalaPickup balaPickup = collision.gameObject.GetComponent<BalaPickup>();
            if (balaPickup != null)
            {
                bulletCount += balaPickup.cantidadDeBalas; // Añadir las balas especificadas
                Debug.Log("Balas recogidas: " + balaPickup.cantidadDeBalas + ". Balas totales: " + bulletCount);
            }
            else
            {
                Debug.LogWarning("El objeto con tag 'Bala' no tiene el componente BalaPickup.");
            }
        }
    }
}