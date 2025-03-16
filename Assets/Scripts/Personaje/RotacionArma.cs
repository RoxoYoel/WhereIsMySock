using UnityEngine;

public class AimAtMouseY : MonoBehaviour
{
    void Update()
    {
        // Obtener la posición del ratón en el mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Fijar la posición Z del ratón para que no se mueva en ese eje (solo usamos X e Y)
        mousePosition.z = transform.position.z;

        // Calcular la dirección del ratón respecto al personaje
        Vector3 direction = mousePosition - transform.position;

        // Calcular el ángulo en el que el objeto debe rotar (en grados)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Establecer la rotación en el eje Z
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
