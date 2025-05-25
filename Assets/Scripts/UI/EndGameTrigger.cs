using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameTrigger : MonoBehaviour
{
    public FinishScene finishScene;
    public Image whiteFadeImage;
    public Image frontWhiteFade;
    public TextMeshProUGUI cronometro;
    public TextMeshProUGUI progreso;
    public float fadeSpeed = 1f;

    private bool isFading = false;
    private bool isFading2 = false;
    private float alpha = 0f;
    private float alpha2 = 1f;


    private void Update()
    {
        if (isFading)
        {
            alpha += fadeSpeed * Time.unscaledDeltaTime;
            whiteFadeImage.color = new Color(1f, 1f, 1f, Mathf.Clamp01(alpha));

            if (alpha >= 1f)
            {
                isFading = false;
                isFading2 = true;
                finishScene.FinishSceneMenu();
                whiteFadeImage.color = new Color(0.247f, 0.247f, 0.247f, Mathf.Clamp01(alpha));
            }
        }

        if (isFading2)
        {
            alpha2 -= fadeSpeed * Time.unscaledDeltaTime;
            frontWhiteFade.color = new Color(1f, 1f, 1f, Mathf.Clamp01(alpha2));

            if (alpha2 <= 0f)
            {
                isFading2 = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            progreso.gameObject.SetActive(false);
            cronometro.gameObject.SetActive(false);
            Time.timeScale = 0f;
            isFading = true;

            if (MusicManager.Instance != null)
            {
                MusicManager.Instance.PlayEndGameMusic();
            }
        }
    }
}
