using UnityEngine;

public class Shoot : MonoBehaviour
{
    public BulletPool bulletPool; // Referencia al pool de balas
    public Items items; // Referencia al script Items para acceder al contador de balas
    Animator anim;
    float secondsCounter = 0;
    float secondsToCount = 0.9f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        secondsCounter += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (secondsCounter >= secondsToCount && items.bulletCount > 0) // Solo disparar si hay balas
            {
                anim.SetTrigger("Shoot");
                Invoke("Disparar", 0.1f);
                items.bulletCount--; // Gastar una bala
            }
        }
    }

    public void Disparar()
    {
        secondsCounter = 0;
        bulletPool.ShootBullet(); // Llamamos directamente al método del pool de balas
    }
}