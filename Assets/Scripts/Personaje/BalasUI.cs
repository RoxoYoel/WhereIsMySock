using UnityEngine;
using UnityEngine.UI;

public class BulletUI : MonoBehaviour
{
    public Text bulletText;
    public Items items; // Referencia al script Items para acceder al contador de balas

    void Update()
    {
        bulletText.text = "Balas: " + items.bulletCount.ToString();
    }
}
