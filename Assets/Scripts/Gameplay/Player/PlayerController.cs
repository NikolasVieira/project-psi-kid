using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float groundCheckDistance = 0.2f;
    private bool isGrounded;
    private float moveInput;
    public LayerMask groundLayer;
    public Transform groundCheck; // Ponto de verificação de solo

    private Rigidbody2D rb;
    private PlayerState currentState;
    private Animator animator;

    public event Action<GameObject> OnTeleportRequest;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        if (animator == null) {
            Debug.LogError("Animator não encontrado em objetos filhos do PlayerController.");
        }
    }

    private void Update() {
        // Verifica se o jogador está no chão
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckDistance, groundLayer);

        moveInput = Input.GetAxisRaw("Horizontal");
        // Alterna as animações
        HandleAnimations();

        // Inverte a escala do sprite dependendo da direção do movimento
        FlipSprite();
        // Realiza o pulo
        if (Input.GetButtonDown("Jump") && isGrounded) {
            Jump();
        }
    }
    private void FixedUpdate() {
        // Movimenta o jogador horizontalmente
        MovePlayer();
    }

    private void MovePlayer() {
        // Move o jogador de acordo com o input
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }
    private void OnEnable() {
        PlayerInputHandler.OnJump += Jump;
        PlayerInputHandler.OnInteraction += HandleInteraction;
    }

    private void OnDisable() {
        PlayerInputHandler.OnJump -= Jump;
    }

    private void HandleInteraction() {
        if (OnTeleportRequest != null) {
            OnTeleportRequest.Invoke(gameObject);
        }
    }

    public void Jump() {
        if (isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void HandleAnimations() {
        if (isGrounded) {
            animator.SetBool("isJumping", false);
            if (moveInput != 0) {
                // Se o jogador está se movendo
                animator.SetBool("isWalking", true);
            } else {
                // Se o jogador não está se movendo
                animator.SetBool("isWalking", false);
            }
        } else {
            // Se o jogador está no ar
            animator.SetBool("isJumping", true);
        }
    }
    private void FlipSprite() {
        // Inverte a direção do sprite com base no movimento horizontal
        if (moveInput > 0) {
            transform.localScale = new Vector3(1, 1, 1); // Normal
        } else if (moveInput < 0) {
            transform.localScale = new Vector3(-1, 1, 1); // Invertido
        }
    }
}
