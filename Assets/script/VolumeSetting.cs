using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer adoMixer;
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("SoundVolume"))
        {
            LoadVolume();
        }
        else
        SetSoundValue();
    }
    public void SetSoundValue()
    {
        float volume = volumeSlider.value;
        adoMixer.SetFloat("Volume", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SoundVolume", volume);
    }
    private void LoadVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("SoundVolume");
        SetSoundValue();
    }

}
