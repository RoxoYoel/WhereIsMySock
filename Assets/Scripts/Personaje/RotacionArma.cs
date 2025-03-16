using UnityEngine;

public class AimAtMouseY : MonoBehaviour
{
    void Update()
    {
        // Obtener la posici�n del rat�n en el mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Fijar la posici�n Z del rat�n para que no se mueva en ese eje (solo usamos X e Y)
        mousePosition.z = transform.position.z;

        // Calcular la direcci�n del rat�n respecto al personaje
        Vector3 direction = mousePosition - transform.position;

        // Calcular el �ngulo en el que el objeto debe rotar (en grados)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Establecer la rotaci�n en el eje Z
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
