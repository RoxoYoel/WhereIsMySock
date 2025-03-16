using UnityEngine;

public class AimAtMouseY : MonoBehaviour
{
    public Move movement;
    private float rotationSpeed = 1000f; // Velocidad de rotación
    SpriteRenderer sp;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        // Obtener el valor del movimiento vertical del ratón (-1 a 1)
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

        // Calcular el ángulo de rotación basado en la entrada del ratón
        float angle = mouseInputY * rotationSpeed * Time.deltaTime;

        // Aplicar la rotación en el eje Z
        transform.Rotate(0, 0, angle);
    }

}
