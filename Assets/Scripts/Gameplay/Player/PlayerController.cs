using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float groundCheckDistance = 0.2f;
    public LayerMask groundLayer;
    public PauseController pauseController;

    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private PlayerState currentState;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;

        playerInput = GetComponent<PlayerInput>();
        if (playerInput == null) {
            Debug.LogError("PlayerInput não encontrado!");
        }
        currentState = new GroundedState();
    }

    void Update() {
        if (currentState == null) {
            Debug.LogError("Estado atual não foi inicializado!");
            return;
        }

        // Delega ao estado atual o controle do input e outras lógicas
        currentState.HandleInput(this);

        Debug.Log(currentState);
    }

    public void Move(float moveInput) {
        if (moveInput != 0) {
            transform.localScale = new Vector3(Mathf.Sign(moveInput), 1, 1);
        }
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    public void Jump() {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    public bool CheckIfGrounded() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * groundCheckDistance, Color.red);
        return hit.collider != null;
    }

    public void Pause() {
        pauseController.ShowPausePanel();
    }

    public void Unpause() {
        pauseController.HidePausePanel();
    }

    public void SetState(PlayerState newState) {
        currentState = newState;
    }

    public PlayerInput GetPlayerInput() {
        return playerInput;
    }
}
