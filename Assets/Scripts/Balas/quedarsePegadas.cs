using UnityEngine;
using System.Collections;

public class quedarsePegadas : MonoBehaviour
{
    public GameObject balaNueva;
    void Start()
    {
        balaNueva.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            gameObject.SetActive(false);
            balaNueva.SetActive(true);
            Instantiate(balaNueva, transform.position, Quaternion.identity).transform.localScale = transform.localScale;
        }
    }

    void Update()
    {
        
    }
}
