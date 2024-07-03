
using FMOD.Studio;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;


public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;

    public GameObject PauseMenuCanvas;

    private EventInstance eventInstance;
    public string fmodEventPath1 = "event:/UI";

    void Start()
    {
        

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlaySoundShow();
            
            if (Paused)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }
    }

    void Stop()
    {
        PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;

        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            Debug.Log($"Suono in esecuzione: {a.name}");
            if (a.name != "PauseMenuMusic")
            {
                a.Pause();
                Debug.Log($"Suono messo in pausa: {a.name}");
            }
        }

        Cursor.lockState = CursorLockMode.None; // Sblocca il cursore
        Cursor.visible = true; // Rende il cursore visibile
    }

    public void Play()
    {
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.UnPause();
        }
        Cursor.lockState = CursorLockMode.Locked; // Blocca il cursore al centro dello schermo
        Cursor.visible = false; // Rende il cursore invisibile       
    }

    public void MainMenuButton()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        SceneManager.LoadScene(0); //per andare al MainMenu
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }
    
    private void PlaySoundShow()
    {
        eventInstance = RuntimeManager.CreateInstance(fmodEventPath1);
        eventInstance.setParameterByName("Type", 3);
        eventInstance.start();
        eventInstance.release();
    }
}
