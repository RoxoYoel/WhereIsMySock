using UnityEngine;

public class AimAtMouseY : MonoBehaviour
{
    public Move movement;
    private float rotationSpeed = 1000f; // Velocidad de rotaci�n
    SpriteRenderer sp;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        // Obtener el valor del movimiento vertical del rat�n (-1 a 1)
        float mouseInputY = Input.GetAxis("Mouse Y");

        // Si el personaje se mueve a la izquierda, invertir el control
        if (sp.flipX == true)
        {
            mouseInputY = -mouseInputY;
        }
        if (sp.flipX == false)
        {
            mouseInputY = +mouseInputY;
        }

        // Calcular el �ngulo de rotaci�n basado en la entrada del rat�n
        float angle = mouseInputY * rotationSpeed * Time.deltaTime;

        // Aplicar la rotaci�n en el eje Z
        transform.Rotate(0, 0, angle);
    }

}
