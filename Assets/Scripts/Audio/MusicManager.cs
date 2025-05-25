using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    public AudioClip menuMusic;
    public AudioClip gameMusic;
    public AudioClip endGameMusic;
    public AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource.clip = menuMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Escena cargada: " + scene.name);

        if (scene.name == "Save UI" || scene.name == "Challenge")
        {
            if (audioSource.clip != gameMusic)
            {
                audioSource.volume = 0.075f;
                audioSource.clip = gameMusic;
                audioSource.Play();
            }
        }
    }

    public void PlayEndGameMusic()
    {
        if (audioSource.clip != endGameMusic)
        {
            audioSource.volume = 0.2f;
            audioSource.clip = endGameMusic;
            audioSource.Play();
        }
    }

}
