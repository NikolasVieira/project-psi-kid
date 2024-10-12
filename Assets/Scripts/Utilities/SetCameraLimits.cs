using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraLimits : MonoBehaviour
{
    public Vector2 newMinPosition;
    public Vector2 newMaxPosition;
    private CameraController cam;

    private void Start() {
        // Inicializa a refer�ncia � c�mera apenas uma vez
        cam = Camera.main.GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            // Atualiza os limites da c�mera com base na sala
            cam.SetCameraLimits(newMinPosition, newMaxPosition);
        }
    }
}
