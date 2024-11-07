using UnityEngine;
using System.Collections;

public abstract class PlayerState {
    protected PlayerController player;
    protected Animator animator;

    public PlayerState(PlayerController player, Animator animator) {
        this.player = player;
        this.animator = animator;
    }

    public abstract void OnEnter();
    public abstract void OnExit();
}

//public class IdleState : PlayerState {
//    public IdleState(PlayerController player, Animator animator) : base(player, animator) { }

//    public override void OnEnter() {
//    }

//    public override void OnExit() {
//    }
//}
//public class WalkingState : PlayerState {
//    public WalkingState(PlayerController player, Animator animator) : base(player, animator) { }

//    public override void OnEnter() {
//        animator.SetBool("isWalking", true);
//    }

//    public override void OnExit() {
//        animator.SetBool("isWalking", false);
//    }
//}


//public class JumpingState : PlayerState {
//    public JumpingState(PlayerController player, Animator animator) : base(player, animator) { }

//    public override void OnEnter() {
//        animator.SetBool("isJumping", true);
//        player.Jump();
//        player.StartCoroutine(WaitForGround()); // Chama uma corrotina para monitorar quando o jogador toca o chão
//    }

//    public override void OnExit() {
//        // Lógica adicional para quando o estado de pulo for encerrado, se necessário
//    }

//    public IEnumerator WaitForGround() {
//        // Enquanto o jogador não tocar o chão, continua no estado de pulo
//        while (!player.isOnGround) {
//            player.CheckIfGrounded(); // Checa o chão durante a corrotina
//            yield return null;  // Espera o próximo quadro
//        }

//        player.CheckIfGrounded(); // Checa o chão durante a corrotina
//        // Quando o jogador tocar o chão, muda para o estado de grounded
//        animator.SetBool("isJumping", false);
//    }
//}
