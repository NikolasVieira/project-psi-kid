using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState {
    public abstract void HandleInput(PlayerController player);
}

public class GroundedState : PlayerState {
    public override void HandleInput(PlayerController player) {
        PlayerInput input = player.GetPlayerInput();
        float moveInput = input.GetHorizontalInput();
        player.Move(moveInput);

        if (input.IsJumpPressed() && player.CheckIfGrounded()) {
            player.Jump();
            player.SetState(new JumpingState());
        }

        if (input.IsPausePressed()) {
            player.Pause();
            player.SetState(new PauseState());
        }
    }
}

public class JumpingState : PlayerState {
    public override void HandleInput(PlayerController player) {
        PlayerInput input = player.GetPlayerInput();
        float moveInput = input.GetHorizontalInput();
        player.Move(moveInput);

        if (player.CheckIfGrounded()) {
            player.SetState(new GroundedState());
        }

        if (input.IsPausePressed()) {
            player.Pause();
            player.SetState(new PauseState());
        }
    }
}

public class PauseState : PlayerState {
    public override void HandleInput(PlayerController player) {
        PlayerInput input = player.GetPlayerInput();

        if (input.IsPausePressed()) {
            player.Unpause();
        }
    }
}
