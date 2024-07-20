
using FMOD.Studio;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;
using UnityEngine.EventSystems;
using UnityEngine.Video;
using CGT;


public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;

    public GameObject PauseMenuCanvas;
    //public VideoPlayer VideoPlayer;
    [SerializeField] private InspectManager inspectManager;
    [SerializeField] private SceneState sceneState;
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
                sceneState.blockMovementPlayer = false;
                inspectManager.TogliBlur();
                Play();
            }
            else
            {
                sceneState.blockMovementPlayer = true;
                inspectManager.AggiungiBlur();
                Stop();
            }
        }
    }

    void Stop()
    {
        PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
        //VideoPlayer.Pause();

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
        Debug.Log("prova");
        //Cursor.lockState = CursorLockMode.None; // Sblocca il cursore
        Cursor.visible = true; // Rende il cursore visibile
    }

    public void Play()
    {
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        //VideoPlayer.Play();

        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.UnPause();
        }
        //Cursor.lockState = CursorLockMode.Locked; // Blocca il cursore al centro dello schermo
        Cursor.visible = false; // Rende il cursore invisibile   
        sceneState.blockMovementPlayer = false;    
    }

    public void MainMenuButton()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        //ResetGame();
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
    public void ResetGame()
    {
        Debug.Log("corretto");
        sceneState.ResetData();
    }
}
