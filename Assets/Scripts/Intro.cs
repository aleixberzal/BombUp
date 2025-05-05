using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public TextMeshProUGUI textBox;
    [TextArea(3, 10)]
    public string[] lines;
    public float charDelay = 0.05f;
    public float linePause = 1.5f;

    public TextMeshProUGUI text;
    public float speed = 2f;
    public float minAlpha = 0.2f;
    public float maxAlpha = 1f;

    private int currentLine = 0;
    private int charIndex = 0;
    private float timer = 0f;
    private string displayedText = "";
    private bool waitingAfterLine = false;
    private bool finished = false;

    void Start()
    {
        textBox.text = "";
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Save UI");
        }

        if (finished)
        {
            float alpha = Mathf.Lerp(minAlpha, maxAlpha, Mathf.PingPong(Time.time * speed, 1f));
            Color color = text.color;
            color.a = alpha;
            text.color = color;
            return;
        }

        timer += Time.deltaTime;

        if (currentLine >= lines.Length)
        {
            finished = true;
            return;
        }

        if (waitingAfterLine)
        {
            if (timer >= linePause)
            {
                waitingAfterLine = false;
                timer = 0f;
                currentLine++;
                charIndex = 0;
            }
            return;
        }

        if (charIndex < lines[currentLine].Length)
        {
            if (timer >= charDelay)
            {
                displayedText += lines[currentLine][charIndex];
                textBox.text = displayedText;
                charIndex++;
                timer = 0f;
            }
        }
        else
        {
            displayedText += "\n";
            waitingAfterLine = true;
            timer = 0f;
        }
    }
}