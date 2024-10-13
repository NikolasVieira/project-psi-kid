using UnityEngine;

public class PressurePlate : MonoBehaviour {
    public GameObject door;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") || collision.CompareTag("Movable")) {
            door.SetActive(false); 
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player") || collision.CompareTag("Movable")) {
            door.SetActive(true);
        }
    }
}