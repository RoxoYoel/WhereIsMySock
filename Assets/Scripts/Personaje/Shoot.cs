using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPool; // Referencia al pool de balas
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
            if (secondsCounter >= secondsToCount)
            {
                anim.SetTrigger("Shoot");
                Invoke("Disparar", 0.1f);
            }
        }
    }

    public void Disparar()
    {
        secondsCounter = 0;
        bulletPool.GetComponent<BulletPool>().ShootBullet(); // Aquí usamos el pool de balas
    }
}
