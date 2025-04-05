using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuConfig : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", 0.5f);
        volumeSlider.value = savedVolume;
        SetVolume(savedVolume);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20f);
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
