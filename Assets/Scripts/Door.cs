using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, InteractInterface
{
    [SerializeField] private string _prompt;
    [SerializeField] Animator _animator;
    public string InteractionPrompt => _prompt;
    //private Vector3 _spawnPosition;
    //public SceneState _sceneState;

    public bool Interact(Interactor interactor)
    {
        if (_prompt == "Exit") {   
           SceneManager.LoadScene("Ambiente iniziale");}
        else 
        {
            _animator.SetBool("aperto", true);
            if (_prompt == "Door-M") { 
                StartCoroutine(LoadNewScene("Corridoio_M"));}
            else if (_prompt == "Door-M1") { 
                StartCoroutine(LoadNewScene("Aula1_M"));}
            else if (_prompt == "Door-M2") {       
                StartCoroutine(LoadNewScene("Aula2_M"));}
            else if (_prompt == "Door-M3") {       
                StartCoroutine(LoadNewScene("Aula3_M"));}
            else if (_prompt == "Door-M4") {       
                StartCoroutine(LoadNewScene("Aula4_M"));}
            else if (_prompt == "Door-M5") {       
                StartCoroutine(LoadNewScene("Aula5_M"));}
            else if (_prompt == "Door-M6") {       
                StartCoroutine(LoadNewScene("Aula6_M"));}
            else
            Debug.Log("Hai aperto la porta!");        
        }
        return true;
    }
    private IEnumerator LoadNewScene(string sceneName)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }

}
