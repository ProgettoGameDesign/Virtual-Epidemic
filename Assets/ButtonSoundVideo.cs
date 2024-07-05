using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Necessario per interagire con il pulsante UI
using FMODUnity; // Necessario per utilizzare FMOD
using FMOD.Studio; // Necessario per lavorare con gli eventi FMOD

public class ButtonSoundVideo : MonoBehaviour
{
    // Assicurati di assegnare questo campo nell'Inspector di Unity
    private string fmodEventPath = "event:/UI";

    private Button button;
    private EventInstance eventInstance;
    private EventInstance mainCameraEventInstance;
    [SerializeField] StudioEventEmitter mainCameraEmitter;

    void Start()
    {
        // Ottieni il componente Button associato a questo GameObject
        button = GetComponent<Button>();

        // Assicurati che il pulsante abbia un componente Button
        if (button != null)
        {
            // Aggiungi l'ascoltatore dell'evento OnClick
            button.onClick.AddListener(PlaySound);
        }

        // Creare un'istanza dell'evento
        eventInstance = RuntimeManager.CreateInstance(fmodEventPath);
        
       
        if (mainCameraEmitter != null)
        {
            mainCameraEventInstance = mainCameraEmitter.EventInstance;
        }
        else
        {
            Debug.LogError("Main Camera does not have a StudioEventEmitter component.");
        }
    }

    void PlaySound()
    {
        // Imposta il parametro "Type" su 3
        eventInstance.setParameterByName("Type", 0);

        // Riproduci l'evento
        eventInstance.start();

        // Rilascia l'istanza dopo aver riprodotto il suono
        eventInstance.release();

        if (mainCameraEventInstance.isValid())
        {
            PLAYBACK_STATE playbackState;
            mainCameraEventInstance.getPlaybackState(out playbackState);

            if (playbackState == PLAYBACK_STATE.PLAYING)
            {
                mainCameraEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            }
            else
            {
                mainCameraEventInstance.start();
            }
        }
        else
        {
            Debug.LogError("Main Camera EventInstance is not valid.");
        }
    }

    void OnDestroy()
    {
        // Assicurati di rilasciare l'istanza quando l'oggetto viene distrutto
        eventInstance.release();
    }
}
