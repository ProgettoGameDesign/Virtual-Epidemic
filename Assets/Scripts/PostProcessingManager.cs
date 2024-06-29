using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class PostProcessingManager : MonoBehaviour
{
    public static PostProcessingManager Instance;

    // Lista di tutti i volumi di post-processing nelle scene
    private List<PostProcessVolume> postProcessVolumes = new List<PostProcessVolume>();
    public bool volumesDisabled = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Metodo per registrare un volume di post-processing
    public void RegisterVolume(PostProcessVolume volume)
    {
        if (!postProcessVolumes.Contains(volume))
        {
            postProcessVolumes.Add(volume);
            Debug.Log("Volume registrato: " + volume.name);

            // Disattiva il volume se volumesDisabled è true
            if (volumesDisabled)
            {
                volume.enabled = false;
            }
        }
    }

    // Metodo per rimuovere un volume di post-processing
    public void UnregisterVolume(PostProcessVolume volume)
    {
        if (postProcessVolumes.Contains(volume))
        {
            postProcessVolumes.Remove(volume);
        }
    }

    // Metodo per disattivare tutti i volumi di post-processing
    public void DisableAllVolumes()
    {
        if (Instance == null)
        {
            Debug.LogError("PostProcessingManager instance is null.");
            return;
        }

        if (postProcessVolumes.Count == 0)
        {
            Debug.LogWarning("No post-processing volumes registered.");
        }

        foreach (var volume in postProcessVolumes)
        {
            volume.enabled = false;
            Debug.Log("Volume disattivato: " + volume.name);
        }
        volumesDisabled = true;
    }

    // Metodo per attivare tutti i volumi di post-processing
    public void EnableAllVolumes()
    {
        foreach (var volume in postProcessVolumes)
        {
            volume.enabled = true;
        }
        volumesDisabled = false;
    }

    // Metodo chiamato quando una scena viene caricata
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        RegisterSceneVolumes();
    }

    // Metodo per registrare tutti i volumi nella scena corrente
    private void RegisterSceneVolumes()
    {
        PostProcessVolume[] volumes = FindObjectsOfType<PostProcessVolume>();
        foreach (var volume in volumes)
        {
            RegisterVolume(volume);
        }
    }
}
