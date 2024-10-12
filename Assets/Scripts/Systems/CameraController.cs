using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform target;  // Jogador ou objeto a seguir
    public float smoothing = 0.5f;  // Suavidade do movimento da câmera
    public Vector2 maxPosition;  // Limite máximo da câmera
    public Vector2 minPosition;  // Limite mínimo da câmera

    private void LateUpdate() {
        if (target != null)  // Garante que o alvo (jogador) está setado
        {
            // Calcula a nova posição da câmera
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // Aplica os limites impostos pela maxPosition e minPosition
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            // Move a câmera suavemente para a nova posição
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
    }

    // Método para ajustar os limites dinamicamente
    public void SetCameraLimits(Vector2 newMinPosition, Vector2 newMaxPosition) {
        minPosition = newMinPosition;
        maxPosition = newMaxPosition;
    }
}
