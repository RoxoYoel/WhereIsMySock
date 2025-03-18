using UnityEngine;
using System.Collections;

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
        
        if (collision.gameObject.CompareTag("Municion"))
        {
            // Desactivar el objeto inmediatamente para evitar doble detección
            collision.gameObject.SetActive(false);
            // Obtener el componente "BalaPickup" para saber cuántas balas dar
            BalaPickup balaPickup = collision.gameObject.GetComponent<BalaPickup>();

            if (bulletCount >= 0)
            {
                
                if (balaPickup != null)
                {
                    bulletCount += balaPickup.cantidadDeBalas; // Añadir las balas especificadas
                    Debug.Log("Balas recogidas: " + balaPickup.cantidadDeBalas + ". Balas totales: " + bulletCount);
                }
            }  
        }
    }
}