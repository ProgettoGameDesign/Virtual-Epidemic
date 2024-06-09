using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, InteractInterface
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    //private Vector3 _spawnPosition;
    //public SceneState _sceneState;

    public bool Interact(Interactor interactor)
    {
        if (_prompt == "Door-M") {
            SceneManager.LoadScene("Corridoio_M");}
        else if (_prompt == "Door-M1") { 
            SceneManager.LoadScene("Aula1_M");}
        else if (_prompt == "Door-M2") {       
            SceneManager.LoadScene("Aula2_M");}
        else if (_prompt == "Door-M3") {       
            SceneManager.LoadScene("Aula3_M");}
        else if (_prompt == "Exit") {   
            SceneManager.LoadScene("Ambiente iniziale");}
        else
        Debug.Log("Hai aperto la porta!");        
        return true;
    }
}
