using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public bool isGrounded;
    public float groundCheckDistance = 0.2f; // Distância do Raycast até o chão
    public LayerMask groundLayer; // Camada que representa o chão

    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private PlayerState currentState;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;

        playerInput = GetComponent<PlayerInput>();
        // Verifique se PlayerInput foi encontrado
        if (playerInput == null) {
            Debug.LogError("PlayerInput não encontrado! Certifique-se de que o componente PlayerInput está adicionado ao GameObject.");
        }
        currentState = new GroundedState();  // Estado inicial
    }

    void Update() {
        if (currentState == null) {
            Debug.LogError("Estado atual não foi inicializado!");
            return;
        }
        isGrounded = CheckIfGrounded(); // Verificar se está no chão usando Raycast
        currentState.HandleInput(this);
    }

    public void Move(float moveInput) {
        if (moveInput > 0) {
            transform.localScale = new Vector3(1, 1, 1); // Olhando para a direita
        } else if (moveInput < 0) {
            transform.localScale = new Vector3(-1, 1, 1); // Olhando para a esquerda
        }
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    public void Jump() {
        if (isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    // Método para verificar se o jogador está no chão usando Raycast
    private bool CheckIfGrounded() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * groundCheckDistance, Color.red);
        return hit.collider != null;
    }

    public void SetState(PlayerState state) {
        currentState = state;
    }

    public PlayerInput GetPlayerInput() {
        return playerInput;
    }
}
