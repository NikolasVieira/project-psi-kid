using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour {
    public Vector2 cameraChange;  // Quanto a câmera deve se mover ao entrar na sala
    public Vector3 playerChange;  // Quanto o jogador deve ser reposicionado
    private CameraController cam;

    private void Start() {
        // Inicializa a referência à câmera apenas uma vez
        cam = Camera.main.GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            // Atualiza os limites da câmera com base na sala
            cam.SetCameraLimits(cam.minPosition + cameraChange, cam.maxPosition + cameraChange);

            // Reposiciona o jogador
            collision.transform.position += playerChange;
        }
    }
}
