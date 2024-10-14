using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Para reiniciar a cena e voltar ao menu
using UnityEngine.UI;  // Para interagir com a UI

public class PauseController : MonoBehaviour
{
    public GameObject pausePanelUI;  // Referência à tela de fase concluída
    public PlayerController player;

    void Start() {
        // Certificar que a UI de fase concluída está desativada no início
        pausePanelUI.SetActive(false);
    }

    // Função para mostrar a tela de fase concluída
    public void ShowPausePanel() {
        // Ativa a UI
        pausePanelUI.SetActive(true);

        // Pausa o jogo se necessário
        Time.timeScale = 0f;  // Opcional: Para o tempo do jogo
    }
    public void HidePausePanel() {
        pausePanelUI.SetActive(false);
        Time.timeScale = 1f;
        if (player.CheckIfGrounded()) {
            player.SetState(new GroundedState());  // Volta ao estado de chão se estiver aterrado
        } else {
            player.SetState(new JumpingState());  // Continua no estado de pulo se estiver no ar
        }
    }
    // Função chamada pelo botão "Reiniciar"
    public void RestartLevel() {
        // Reinicia a cena atual
        Time.timeScale = 1f;  // Reseta o tempo do jogo antes de reiniciar
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Função chamada pelo botão "Voltar ao Menu"
    public void LoadMainMenu() {
        Time.timeScale = 1f;  // Reseta o tempo do jogo antes de voltar ao menu
        SceneManager.LoadScene(0);  // Certifique-se que o nome da cena do menu está correto
    }
}
