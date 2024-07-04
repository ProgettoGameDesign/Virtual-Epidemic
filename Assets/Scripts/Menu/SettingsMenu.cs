
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject volumeMusicSlider;
    public GameObject volumeFxSlider;
    public GameObject sensitivitySlider;
    //public GameObject backButton;

    //public AudioMixer audioMixer;

    public static float adjustedSensitivity = 0.5f;
    public static float sliderMusicValue = 1f;
    public static float sliderFxValue = 1f;

    public void Start()
    {
        sensitivitySlider.GetComponent<Slider>().value = adjustedSensitivity;
        volumeMusicSlider.GetComponent<Slider>().value = sliderMusicValue;
        volumeFxSlider.GetComponent<Slider>().value = sliderFxValue;
        //audioMixer.SetFloat("MyExposedVolume", volumeSlider.GetComponent<Slider>().value );
    }
    public void SetVolumeMusic(float volumeMusic)
    {
        //Debug.Log(volume);
        sliderMusicValue = volumeMusic;
        //audioMixer.SetFloat("MyExposedVolume", Mathf.Log10(sliderMusicValue) * 20); -> AUDIO MIXER MUSIC DA LINKARE
    }
    public void SetVolumeFx(float volumeFx)
    {
        //Debug.Log(volume);
        sliderMusicValue = volumeFx;
        //audioMixer.SetFloat("MyExposedVolume", Mathf.Log10(sliderFxValue) * 20); -> AUDIO MIXER FX DA LINKARE
    }

    public void SetSensitivity(float sensitivity)
    {
        adjustedSensitivity = sensitivity;
    }
}