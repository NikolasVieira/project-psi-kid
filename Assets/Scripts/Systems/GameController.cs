using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TMP_Text timerText;  // Refer�ncia ao objeto TMP_Text no Canvas
    private float timeRemaining = 600f;  // 10 minutos em segundos (10 * 60)
    private bool timerIsRunning = false;

    void Start() {
        timerIsRunning = true;
    }

    void Update() {
        Timer();
    }

    public void Timer() {
        if (timerIsRunning) {
            if (timeRemaining > 0) {
                // Reduz o tempo restante
                timeRemaining -= Time.deltaTime;

                // Converte o tempo restante em minutos e segundos
                int minutes = Mathf.FloorToInt(timeRemaining / 60);
                int seconds = Mathf.FloorToInt(timeRemaining % 60);

                // Atualiza o texto do cron�metro
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            } else {
                // O tempo acabou
                timerIsRunning = false;
                timeRemaining = 0;

                // Certifique-se de exibir 00:00 quando o cron�metro acabar
                timerText.text = "00:00";
            }
        }
    }
}