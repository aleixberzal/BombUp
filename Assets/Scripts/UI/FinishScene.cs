using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishScene : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Cronometro cronometro;
    public GameObject finishSceneUI;
    public AudioSource audioSource;

    public bool challengeDefeat = false;
    public string textProgress = "";

    void Start()
    {
        scoreText.text = "";
        finishSceneUI.SetActive(false);
    }

    public void FinishSceneMenu()
    {
        finishSceneUI.SetActive(true);
        if (audioSource != null)
            audioSource.Stop();

        if (challengeDefeat)
        {
            scoreText.text = "Congratulations! You reached " + textProgress + " in 5 minutes!";
        } else
        {
            int minutes = Mathf.FloorToInt(cronometro.tiempoTranscurrido / 60f);
            int seconds = Mathf.FloorToInt(cronometro.tiempoTranscurrido % 60f);

            scoreText.text = "You finished the game in: " + minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }

    public void Creditos()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Creditos");
    }
}
