using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.UI;

public class VcaController : MonoBehaviour
{
    // Start is called before the first frame update
    public string path = "";
    private Slider slider;
    private VCA vca;
    [SerializeField] private SceneState sceneState;
    
    void Start()
    {
        vca = RuntimeManager.GetVCA(path);
        slider = GetComponent<Slider>();
        /*
        if (gameObject.name == "VolumeMusicSlider")
            slider.value = sceneState.sliderMusica;
        else
            slider.value = sceneState.sliderSonoro;*/
        
    }
    void Update()
    {
        if (gameObject.name == "VolumeMusicSlider")
            slider.value = sceneState.sliderMusica;
        else
            slider.value = sceneState.sliderSonoro;
    }
   public void SetVolume(float volume)
   {
    
    vca.setVolume(volume);
    if (gameObject.name == "VolumeMusicSlider")
        sceneState.sliderMusica = volume;
    else
        sceneState.sliderSonoro = volume;
   }
}
