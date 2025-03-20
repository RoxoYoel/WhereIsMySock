using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public int bulletPoolSize = 5;
    public GameObject bulletPrefab; // Cambiado de 'bullet' a 'bulletPrefab' para mayor claridad
    private GameObject[] bullets;
    public int shootNumber = -1;

    void Start()
    {
        bullets = new GameObject[bulletPoolSize];
        for (int i = 0; i < bulletPoolSize; i++)
        {
            bullets[i] = Instantiate(bulletPrefab, transform);
            bullets[i].transform.parent = null;
            bullets[i].SetActive(false);
        }
    }

    public void ShootBullet()
    {
        shootNumber++;
        if (shootNumber >= bulletPoolSize) // Cambiado a >= para mayor claridad
        {
            shootNumber = 0;
        }

        bullets[shootNumber].SetActive(false); // Desactivar antes de cambiar posición y rotación
        bullets[shootNumber].transform.position = transform.position; // Disparo desde la posición del personaje
        bullets[shootNumber].transform.rotation = transform.rotation;
        bullets[shootNumber].transform.localScale = transform.localScale;
        bullets[shootNumber].SetActive(true); // Activar la bala
    }
}