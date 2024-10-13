using UnityEngine;

public class Elevator : MonoBehaviour {
    public float speed = 4f; // Velocidade de descida
    private bool isPlayerOnPlatform = false; // Verifica se o jogador está na plataforma
    private Rigidbody2D rb;
    private Transform player; // Armazena a referência ao jogador

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (isPlayerOnPlatform && player != null) {
            // Move a plataforma para baixo
            Vector2 targetPosition = rb.position + new Vector2(0, -speed * Time.deltaTime);
            rb.MovePosition(targetPosition);

            // Mova o jogador junto com a plataforma na mesma velocidade
            Vector2 playerPosition = player.position;
            player.position = new Vector2(playerPosition.x, playerPosition.y - speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // Verifica se o objeto que colidiu é o jogador
        if (collision.gameObject.CompareTag("Player")) {
            isPlayerOnPlatform = true;
            player = collision.transform; // Armazena a referência ao jogador
            player.SetParent(transform); // Faz o jogador ser filho da plataforma
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        // Verifica se o jogador saiu da plataforma
        if (collision.gameObject.CompareTag("Player")) {
            isPlayerOnPlatform = false;
            player.SetParent(null); // Remove o jogador da plataforma
            player = null; // Limpa a referência ao jogador
        }
    }
}
