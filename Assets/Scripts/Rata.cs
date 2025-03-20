using UnityEngine;

public class MovimientoConFlip : MonoBehaviour
{
    public Vector2 puntoInicial; // Punto inicial
    public Vector2 puntoFinal;   // Punto final
    public float velocidad = 5f; // Velocidad de movimiento

    private Vector3 direccion;  // Direcci�n actual
    private bool yendoHaciaFinal = true; // Estado de direcci�n

    void Start()
    {
        direccion = (puntoFinal - puntoInicial).normalized; // Inicializa direcci�n
        transform.position = puntoInicial; // Coloca al personaje en el punto inicial
    }

    void Update()
    {
        transform.position += direccion * velocidad * Time.deltaTime; 

        // Cambia de direcci�n y hace flip al llegar a un punto
        if (Vector3.Distance(transform.position, yendoHaciaFinal ? puntoFinal : puntoInicial) < 0.1f)
        {
            direccion = (yendoHaciaFinal ? puntoInicial - puntoFinal : puntoFinal - puntoInicial).normalized;
            yendoHaciaFinal = !yendoHaciaFinal; 
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z); // Flip en X
        }
    }
}