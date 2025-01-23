using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class VolumeCTRL : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    void Start()
    {
        if (audioSource != null && volumeSlider != null)
        {
            volumeSlider.value = audioSource.volume;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    void Update()
    {
        
    }
    public void SetVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }
}
