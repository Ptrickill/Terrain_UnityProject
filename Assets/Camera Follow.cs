using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El objeto que la c�mara seguir� (la c�psula)
    public Vector3 offset = new Vector3(0, 2, -5); // Distancia relativa al personaje

    void LateUpdate()
    {
        // Actualizar la posici�n de la c�mara para que siga al personaje
        transform.position = target.position + offset;

        // Hacer que la c�mara mire al personaje
        transform.LookAt(target);
    }
}