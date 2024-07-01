using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Necessario per interagire con il pulsante UI
using FMODUnity; // Necessario per utilizzare FMOD

public class ButtonSound : MonoBehaviour
{
    // Assicurati di assegnare questo campo nell'Inspector di Unity
    public string fmodEventPath;

    private Button button;

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
    }

    void PlaySound()
    {
        // Utilizza FMODUnity.RuntimeManager per riprodurre l'evento sonoro
        RuntimeManager.PlayOneShot(fmodEventPath);
    }
}
