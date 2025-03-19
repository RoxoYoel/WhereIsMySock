using UnityEngine;

public class DesapBala : MonoBehaviour
{
    void Start()
    {
        Invoke("Ocultar", 60f);
    }
    public void Ocultar()
    {
        gameObject.SetActive(false);
    }


}
