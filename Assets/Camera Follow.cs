using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El objeto que la cámara seguirá (la cápsula)
    public Vector3 offset = new Vector3(0, 2, -5); // Distancia relativa al personaje

    void LateUpdate()
    {
        // Actualizar la posición de la cámara para que siga al personaje
        transform.position = target.position + offset;

        // Hacer que la cámara mire al personaje
        transform.LookAt(target);
    }
}