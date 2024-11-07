using UnityEngine;

public class ChangeCam: MonoBehaviour {
    [SerializeField] private int CamIndex;
    private CameraController cam;

    private void Start() {
        // Inicializa a referência à câmera apenas uma vez
        cam = Camera.main.GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            // Atualiza os limites da câmera com base na sala
            cam.ChangeCam(CamIndex);
        }
    }
}
