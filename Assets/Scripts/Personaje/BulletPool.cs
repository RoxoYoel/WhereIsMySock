using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public int bulletPoolSize = 5;
    public GameObject bullet;
    private GameObject[] bullets;
    public int shootNumber = -1;

    void Start()
    {
        bullets = new GameObject[bulletPoolSize];
        for (int i = 0; i < bulletPoolSize; i++)
        {
            bullets[i] = Instantiate(bullet, transform);
            bullets[i].transform.parent = null;
            bullets[i].SetActive(false);
        }
    }

    public void ShootBullet()
    {
        shootNumber++;
        if (shootNumber > 4)
        {
            shootNumber = 0;
        }

        bullets[shootNumber].SetActive(false);
        bullets[shootNumber].transform.position = transform.position; // Disparo desde la posici�n del personaje
        bullets[shootNumber].transform.rotation = transform.rotation; // Aseg�rate de que la rotaci�n est� correcta
        bullets[shootNumber].SetActive(true);
    }
}
