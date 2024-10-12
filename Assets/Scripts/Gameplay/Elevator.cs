using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {
    public float moveSpeed = 2f;  // Velocidade do movimento do elevador
    public Transform lowerPosition;  // Posição final (mais baixa) do elevador
    public Transform upperPosition;  // Posição inicial (mais alta) do elevador
    private bool isMovingDown = false;  // Controle se o elevador está se movendo para baixo

    private void Start() {
        // Garante que o elevador comece na posição superior
        transform.position = upperPosition.position;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player"))  // Verifica se o objeto colidido é o jogador
        {
            isMovingDown = true;  // Inicia o movimento do elevador
        }
    }

    private void Update() {
        if (isMovingDown) {
            // Move o elevador para a posição mais baixa
            Vector3 newElevatorPosition = Vector3.MoveTowards(transform.position, lowerPosition.position, moveSpeed * Time.deltaTime);
            transform.position = newElevatorPosition;

            // Verifica se o elevador chegou na posição mais baixa
            if (Vector3.Distance(transform.position, lowerPosition.position) < 0.01f) {
                isMovingDown = false;  // Para o movimento quando atinge o limite inferior
            }
        }
    }
}
