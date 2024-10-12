using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform target;  // Jogador ou objeto a seguir
    public float smoothing = 0.5f;  // Suavidade do movimento da c�mera
    public Vector2 maxPosition;  // Limite m�ximo da c�mera
    public Vector2 minPosition;  // Limite m�nimo da c�mera

    private void LateUpdate() {
        if (target != null)  // Garante que o alvo (jogador) est� setado
        {
            // Calcula a nova posi��o da c�mera
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // Aplica os limites impostos pela maxPosition e minPosition
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            // Move a c�mera suavemente para a nova posi��o
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
    }

    // M�todo para ajustar os limites dinamicamente
    public void SetCameraLimits(Vector2 newMinPosition, Vector2 newMaxPosition) {
        minPosition = newMinPosition;
        maxPosition = newMaxPosition;
    }
}
