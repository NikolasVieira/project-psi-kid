using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Para reiniciar a cena e voltar ao menu
using UnityEngine.UI;  // Para interagir com a UI

public class EndGame : MonoBehaviour
{
    public GameObject levelCompleteUI;  // Referência à tela de fase concluída

    void Start() {
        // Certificar que a UI de fase concluída está desativada no início
        levelCompleteUI.SetActive(false);
    }

    // Método chamado quando o jogador colidir com a linha de chegada
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))  // Verifica se o jogador passou
        {
            ShowLevelComplete();
        }
    }

    // Função para mostrar a tela de fase concluída
    void ShowLevelComplete() {
        // Ativa a UI
        levelCompleteUI.SetActive(true);

        // Pausa o jogo se necessário
        Time.timeScale = 0f;  // Opcional: Para o tempo do jogo
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
