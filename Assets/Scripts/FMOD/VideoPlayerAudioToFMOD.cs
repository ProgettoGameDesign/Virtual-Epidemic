using UnityEngine;
using UnityEngine.Video;
using FMODUnity;
using FMOD.Studio;

public class VideoPlayerAudioToFMOD : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string fmodEventPath;

    private EventInstance eventInstance;

    void Start()
    {
        // Creare un'istanza dell'evento FMOD
        eventInstance = RuntimeManager.CreateInstance(fmodEventPath);

        // Configura l'output audio del VideoPlayer
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        var audioSource = gameObject.AddComponent<AudioSource>();
        videoPlayer.SetTargetAudioSource(0, audioSource);
        
        // Inizia la riproduzione del video
        videoPlayer.Play();

        // Inizia la riproduzione dell'evento FMOD
        eventInstance.start();
    }

    void Update()
    {
        // Sincronizzare l'audio FMOD con l'audio del VideoPlayer
        if (videoPlayer.isPlaying)
        {
            float[] samples = new float[2048];
            videoPlayer.GetTargetAudioSource(0).GetOutputData(samples, 0);
            // Trasferisci i dati audio a FMOD se necessario
        }
    }

    void OnDestroy()
    {
        // Assicurati di rilasciare l'istanza dell'evento quando l'oggetto viene distrutto
        eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        eventInstance.release();
    }
}
