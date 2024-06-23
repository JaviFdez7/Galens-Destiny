using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour

{
    public float moveSpeed = 1f; // Velocidad de movimiento
    public float moveDistance = 2f; // Distancia máxima de movimiento desde el punto original

    private Vector3 originalPosition; // Posición original del objeto

    void Start()
    {
        // Guardar la posición original del objeto
        originalPosition = transform.position;
    }

    void Update()
    {
        // Calcular un punto aleatorio dentro del rango especificado
        float randomX = Random.Range(originalPosition.x - moveDistance, originalPosition.x + moveDistance) % 2;
        float randomY = Random.Range(originalPosition.y - moveDistance, originalPosition.y + moveDistance) % 2;

        // Mover el objeto hacia el punto aleatorio
        Vector3 targetPosition = new Vector3(randomX, randomY, originalPosition.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
