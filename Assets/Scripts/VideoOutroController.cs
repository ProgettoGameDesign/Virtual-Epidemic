using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VideoOutroController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public RawImage rawImage;
    public string menuSceneName = "MenuScene"; // Nome della scena del menu

    void Start()
    {
        // Assicurati che il video inizi a riprodursi
        videoPlayer.Play();

        // Collega l'evento al metodo che verrà chiamato quando il video sarà finito
        videoPlayer.loopPointReached += OnVideoEnd;

        // Imposta la texture del video sul RawImage
        videoPlayer.prepareCompleted += OnVideoPrepared;
        videoPlayer.Prepare();
    }

    void OnVideoPrepared(VideoPlayer vp)
    {
        rawImage.texture = videoPlayer.texture;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Carica la scena del menu quando il video finisce
        SceneManager.LoadScene(menuSceneName);
    }
}
