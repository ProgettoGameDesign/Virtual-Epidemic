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
    
    void Start()
    {
        vca = RuntimeManager.GetVCA(path);
        slider = GetComponent<Slider>();
        
    }

   public void SetVolume(float volume)
   {
    float volumeInDecibels = Mathf.Log10(Mathf.Max(volume, 0.0001f)) * 20f;

        // Converti i decibel in un range lineare di volume (0-1)
    float volumeLinear = Mathf.Pow(10f, volumeInDecibels / 20f);
    vca.setVolume(volumeLinear);

   }
}
