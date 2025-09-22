using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonedaMovimiento : MonoBehaviour
{
        public float moveSpeed = 5f; // Velocidad de movimiento
    public float destroyXPosition = -10f; // Punto donde el obst�culo se destruye

    void Update()
    {
        // Mueve el obst�culo hacia la izquierda
        if (!Input.GetKey(KeyCode.S))
        {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        // Destruye el obst�culo cuando sale de la pantalla
        if (transform.position.x < destroyXPosition)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            Debug.Log("Moneda recogida!");
            Destroy(gameObject);
        }
    }
}
