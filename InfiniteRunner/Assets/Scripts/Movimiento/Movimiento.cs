using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [Header("Player Settings")]
    public float jumpForce = 7f; // Fuerza del salto
    public float crouchScale = 0.5f; // Tama�o del jugador al agacharse
    //public float crouchDuration = 0.5f; // Duraci�n de la animaci�n de agacharse
    public int maxJumps = 2;

    private Rigidbody rb;
    private Vector3 originalScale;
    private bool isGrounded = true;
    //private bool isCrouching = false;
    private int jumpCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalScale = transform.localScale; // Guarda el tama�o original
    }

    void Update()
    {
        // Saltar
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount++;
            isGrounded = false;
        }

        if (isGrounded == true)
        {
            jumpCount = 0;
        }

        // Agacharse
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(originalScale.x, originalScale.y *crouchScale, originalScale.z);
        }
        else
        {
            transform.localScale = originalScale;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // Corrutina para agacharse y volver a su tama�o normal
    // private System.Collections.IEnumerator Crouch()
    //{
    //    isCrouching = true;
    //    transform.localScale = new Vector3(originalScale.x, originalScale.y * crouchScale, originalScale.z);
    //    yield return new WaitForSeconds(crouchDuration);
    //    transform.localScale = originalScale;
    //    isCrouching = false;
    //}
}