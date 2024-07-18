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
    
    vca.setVolume(volume);

   }
}
