using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState {
    public abstract void HandleInput(PlayerController player);
}

public class GroundedState : PlayerState {
    public override void HandleInput(PlayerController player) {
        PlayerInput input = player.GetPlayerInput();  // Acessa o PlayerInput a partir do PlayerController

        // Movimento lateral
        float moveInput = input.GetHorizontalInput();
        player.Move(moveInput);

        // Verifica se o botão de pulo foi pressionado
        if (input.IsJumpPressed() && player.isGrounded) {
            player.Jump();
            player.SetState(new JumpingState());  // Muda para o estado de pulo
        }
    }
}

public class JumpingState : PlayerState {
    public override void HandleInput(PlayerController player) {
        // Obtém o PlayerInput
        PlayerInput input = player.GetPlayerInput();

        // Movimento lateral enquanto está no ar
        float moveInput = input.GetHorizontalInput();
        player.Move(moveInput);

        // Checar se o jogador aterrissou
        if (player.isGrounded) {
            player.SetState(new GroundedState());
        }
    }
}