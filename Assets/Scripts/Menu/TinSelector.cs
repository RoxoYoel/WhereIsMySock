using System.Collections;
using UnityEngine;

public class TinSelector : MonoBehaviour
{
    public Transform[] ranuras;
    public float velocidad = 10f;
    int indiceActual = 0;
    bool moviendose = false;
    float tin;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        tin = transform.position.x;
    }

    void MoverAPosicion(float destino)
    {
        StartCoroutine(MoverPersonaje(destino));
    }

    IEnumerator MoverPersonaje(float destino)
    {
        moviendose = true;
        //anim.SetBool("Run", true);

        if (tin!=destino)
        {
            transform.Translate(new Vector2(destino,0) * velocidad);
            yield return null;
        }

        //anim.SetBool("Run", false);
        moviendose = false;

    }
    
    void Update()
    {
        if (!moviendose)
        {
           
            if (Input.GetKeyDown(KeyCode.D) && indiceActual < ranuras.Length - 1)
            {
                indiceActual++;
                MoverAPosicion(ranuras[indiceActual].position.x);
            }
            else if (Input.GetKeyDown(KeyCode.A) && indiceActual > 0)
            {
                indiceActual--;
                MoverAPosicion(ranuras[indiceActual].position.x);
            }
        }
    }
}
