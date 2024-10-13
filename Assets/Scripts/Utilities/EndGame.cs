using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Para reiniciar a cena e voltar ao menu
using UnityEngine.UI;  // Para interagir com a UI

public class EndGame : MonoBehaviour
{
    public GameObject levelCompleteUI;  // Refer�ncia � tela de fase conclu�da

    void Start() {
        // Certificar que a UI de fase conclu�da est� desativada no in�cio
        levelCompleteUI.SetActive(false);
    }

    // M�todo chamado quando o jogador colidir com a linha de chegada
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))  // Verifica se o jogador passou
        {
            ShowLevelComplete();
        }
    }

    // Fun��o para mostrar a tela de fase conclu�da
    void ShowLevelComplete() {
        // Ativa a UI
        levelCompleteUI.SetActive(true);

        // Pausa o jogo se necess�rio
        Time.timeScale = 0f;  // Opcional: Para o tempo do jogo
    }

    // Fun��o chamada pelo bot�o "Reiniciar"
    public void RestartLevel() {
        // Reinicia a cena atual
        Time.timeScale = 1f;  // Reseta o tempo do jogo antes de reiniciar
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Fun��o chamada pelo bot�o "Voltar ao Menu"
    public void LoadMainMenu() {
        Time.timeScale = 1f;  // Reseta o tempo do jogo antes de voltar ao menu
        SceneManager.LoadScene(0);  // Certifique-se que o nome da cena do menu est� correto
    }
}
