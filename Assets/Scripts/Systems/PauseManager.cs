using UnityEngine;

public class PauseManager : MonoBehaviour {
    private bool isPaused = false;
    public GameObject pausePanelUI;  // Referência à tela de fase concluída
    void Start() {
        // Certificar que a UI de fase concluída está desativada no início
        pausePanelUI.SetActive(false);

    }
    private void OnEnable() {
        PlayerInputHandler.OnPause += TogglePause; // Inscreve-se no evento de pausa
        GameManager.OnUnpause += TogglePause;
    }

    private void OnDisable() {
        PlayerInputHandler.OnPause -= TogglePause; // Desinscreve-se do evento quando o objeto for destruído
        GameManager.OnUnpause -= TogglePause;
    }

    void TogglePause() {
        if (isPaused) {
            ResumeGame();
        } else {
            PauseGame();
        }
    }

    void PauseGame() {
        Time.timeScale = 0f; // Pausa o tempo do jogo
        isPaused = true;
        pausePanelUI.SetActive(true);
    }

    void ResumeGame() {
        Time.timeScale = 1f; // Retoma o tempo normal do jogo
        isPaused = false;
        pausePanelUI.SetActive(false);
    }
}
