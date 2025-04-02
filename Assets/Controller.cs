using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 5f; // Velocidad de movimiento
    public float gravity = -9.81f; // Gravedad
    public float mouseSensitivity = 100f; // Sensibilidad del ratón para rotar
    private Vector3 velocity; // Para manejar la gravedad

    void Start()
    {
        // Obtener el CharacterController
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogError("CharacterController no encontrado en el objeto!");
        }
    }

    void Update()
    {
        // Movimiento (W/S/A/D)
        float x = Input.GetAxis("Horizontal"); // A/D o flechas izquierda/derecha
        float z = Input.GetAxis("Vertical");   // W/S o flechas arriba/abajo
        Vector3 move = transform.right * x + transform.forward * z;
        move = Vector3.ClampMagnitude(move, 1f) * speed;

        // Rotación con el ratón (solo el personaje, no la cámara)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(0, mouseX, 0);

        // Aplicar gravedad
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = 0f;
        }

        // Mover el personaje
        controller.Move((move + velocity) * Time.deltaTime);
    }
}