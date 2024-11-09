using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static event Action OnUnpause;

    // Tentar de novo após finalizar
    public void TryAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Reinicia o nível atual
    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        OnUnpause?.Invoke();
    }

    // Carrega a cena do menu principal
    public void LoadMainMenu() {
        SceneManager.LoadScene(0);
        OnUnpause?.Invoke();
    }
}
