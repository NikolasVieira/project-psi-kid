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
//        player.StartCoroutine(WaitForGround()); // Chama uma corrotina para monitorar quando o jogador toca o ch�o
//    }

//    public override void OnExit() {
//        // L�gica adicional para quando o estado de pulo for encerrado, se necess�rio
//    }

//    public IEnumerator WaitForGround() {
//        // Enquanto o jogador n�o tocar o ch�o, continua no estado de pulo
//        while (!player.isOnGround) {
//            player.CheckIfGrounded(); // Checa o ch�o durante a corrotina
//            yield return null;  // Espera o pr�ximo quadro
//        }

//        player.CheckIfGrounded(); // Checa o ch�o durante a corrotina
//        // Quando o jogador tocar o ch�o, muda para o estado de grounded
//        animator.SetBool("isJumping", false);
//    }
//}
