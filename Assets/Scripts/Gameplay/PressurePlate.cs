using UnityEngine;

public class PressurePlate : MonoBehaviour {
    public GameObject door; // A porta que será aberta
    private bool isActivated = false;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") || collision.CompareTag("Movable")) {
            isActivated = true;
            door.SetActive(false); // Desativa a porta (abre)
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player") || collision.CompareTag("Movable")) {
            isActivated = false;
            door.SetActive(true); // Ativa a porta novamente (fecha)
        }
    }
}
