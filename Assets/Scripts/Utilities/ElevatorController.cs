using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour {
    public Transform pontoDestino;  // Ponto para onde o jogador será teleportado
    private bool playerOnElevator = false;
    private PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            playerOnElevator = true;
            playerController = collision.GetComponent<PlayerController>();

            // Subscreve ao evento de teleporte
            if (playerController != null) {
                playerController.OnTeleportRequest += TeleportPlayer;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            playerOnElevator = false;

            // Remove a subscrição do evento
            if (playerController != null) {
                playerController.OnTeleportRequest -= TeleportPlayer;
            }
        }
    }

    private void TeleportPlayer(GameObject player) {
        if (playerOnElevator) {
            player.transform.position = pontoDestino.position;
        }
    }
}
