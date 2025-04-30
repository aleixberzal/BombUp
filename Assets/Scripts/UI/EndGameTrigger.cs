using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameTrigger : MonoBehaviour
{
    public FinishScene finishScene;
    public Image whiteFadeImage;
    public float fadeSpeed = 1f;

    private bool isFading = false;
    private float alpha = 0f;

    private void Update()
    {
        if (isFading)
        {
            alpha += fadeSpeed * Time.unscaledDeltaTime;
            whiteFadeImage.color = new Color(1f, 1f, 1f, Mathf.Clamp01(alpha));

            if (alpha >= 1f)
            {
                finishScene.FinishSceneMenu();
                isFading = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            Time.timeScale = 0f;
            isFading = true;
        }
    }
}
