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
    public SceneState _sceneState;

    public bool Interact(Interactor interactor)
    {
        if (_prompt == "Exit") {   
           SceneManager.LoadScene("Ambiente iniziale");}
        else 
        {
            if (_prompt == "Door-M") {
                _animator.SetBool("aperto", true);
                StartCoroutine(LoadNewScene("Corridoio_M"));}
            else if (_prompt == "Door-M1") {
                _animator.SetBool("aperto", true); 
                StartCoroutine(LoadNewScene("Aula1_M"));}
            else if (_prompt == "Door-M2") {  
                _animator.SetBool("aperto", true);     
                StartCoroutine(LoadNewScene("Aula2_M"));}
            else if (_prompt == "Door-M3") {     
                if (_sceneState._hasKey == true) 
                {
                    _animator.SetBool("aperto", true);
                    StartCoroutine(LoadNewScene("Aula3_M"));
                }
                else
                    Debug.Log("Trova chiave per entrare");}
            else if (_prompt == "Door-M4") {
                _animator.SetBool("aperto", true);       
                StartCoroutine(LoadNewScene("Aula4_M"));}
            else if (_prompt == "Door-M5") {
                _animator.SetBool("aperto", true);       
                StartCoroutine(LoadNewScene("Aula5_M"));}
            else if (_prompt == "Door-M6") {
                _animator.SetBool("aperto", true);       
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
