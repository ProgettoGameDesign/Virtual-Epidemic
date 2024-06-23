using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{

    private EventInstance musicEventInstance;
    public static AudioManager instance { get; private set; } 

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in this scene.");
        }
        instance = this;
    }
    
    private void Start()
    {
        InitializeMusic(FMODEvents.instance.music);
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    private void InitializeMusic(EventReference musicEventReference)
    {
        //musicEventInstance = CreateInstance(musicEventReference);
       // musicEventInstance.start();
    }
}
