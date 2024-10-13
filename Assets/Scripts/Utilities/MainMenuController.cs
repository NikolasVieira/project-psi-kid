using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class MainMenuController : MonoBehaviour {
    public GameObject settingsPanel;

    public void StartGame() {
        SceneManager.LoadScene(1);
    }
    public void OpenSettings() {
        settingsPanel.SetActive(true);
    }
    public void CloseSettings() {
        settingsPanel.SetActive(false);
    }
    public void ExitGame() {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
