using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public int bulletPoolSize = 5;
    public GameObject bulletPrefab; // Cambiado de 'bullet' a 'bulletPrefab' para mayor claridad
    private GameObject[] bullets;
    public int shootNumber = -1;
    public GameObject gun;
    float z;
    float y;

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

    private void Update()
    {
        z = gun.transform.rotation.z;
        y = transform.rotation.y;
        print(z);
        
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
        bullets[shootNumber].transform.rotation = gun.transform.rotation;
        //bullets[shootNumber].transform.position = transform.localScale;
        //bullets[shootNumber].transform.rotation = Quaternion.Euler(0, y, z); // Asegúrate de que la rotación esté correcta
        bullets[shootNumber].SetActive(true); // Activar la bala
    }
}