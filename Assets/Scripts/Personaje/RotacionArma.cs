using UnityEngine;

public class AimAtMouseY : MonoBehaviour
{
    public Move movement;
    private float rotationSpeed = 1000f; // Velocidad de rotación
    private SpriteRenderer sp;
    private int directionMultiplier = 1; // 1 cuando mira a la derecha, -1 cuando mira a la izquierda

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Guardamos la rotación actual antes de hacer cambios
        float currentAngle = transform.eulerAngles.z;

        // Convertimos el ángulo para que esté en el rango de -180 a 180 (evitar acumulaciones erróneas)
        if (currentAngle > 180)
            currentAngle -= 360;

        // Si el personaje cambia de dirección, ajustamos la rotación
        if (sp.flipX && directionMultiplier != -1)
        {
            directionMultiplier = -1;
            transform.rotation = Quaternion.Euler(0, 0, -Mathf.Abs(currentAngle));
        }
        else if (!sp.flipX && directionMultiplier != 1)
        {
            directionMultiplier = 1;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Abs(currentAngle));
        }

        // Obtener el valor del movimiento vertical del ratón (-1 a 1)
        float mouseInputY = Input.GetAxis("Mouse Y");

        // Calcular el ángulo de rotación basado en la entrada del ratón
        float angle = mouseInputY * rotationSpeed * Time.deltaTime * directionMultiplier;

        // Aplicar la rotación en el eje Z
        transform.Rotate(0, 0, angle);

    }
}
