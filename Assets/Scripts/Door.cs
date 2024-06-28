using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, InteractInterface
{
    [SerializeField] private string _prompt;
    [SerializeField] Animator _animator;
    [SerializeField] private GameObject CanvasPorta3;
    public string InteractionPrompt => _prompt;
    //private Vector3 _spawnPosition;
    public SceneState _sceneState;

    public bool Interact(Interactor interactor)
    {
        if (_prompt == "Exit") {   
           SceneManager.LoadScene("Ambiente iniziale");
            //AudioManager.instance.PlayOneShot(FMODEvents.instance.openDoor, this.transform.position);
            }
        else 
        {

            if (_prompt == "Door-M")
            {
                _animator.SetBool("aperto", true);
                StartCoroutine(LoadNewScene("Corridoio_M"));
                //AudioManager.instance.PlayOneShot(FMODEvents.instance.openDoor, this.transform.position);
            }
            else if (_prompt == "Door-M1")
            {
                _animator.SetBool("aperto", true);
                StartCoroutine(LoadNewScene("Aula1_M"));
                //AudioManager.instance.PlayOneShot(FMODEvents.instance.openDoor, this.transform.position);
            }
            else if (_prompt == "Door-M2")
            {
                _animator.SetBool("aperto", true);
                StartCoroutine(LoadNewScene("Aula2_M"));
                //AudioManager.instance.PlayOneShot(FMODEvents.instance.openDoor, this.transform.position);
            }
            else if (_prompt == "Door-M3")
            {
                if (_sceneState._hasKey == true)

                {
                    _animator.SetBool("aperto", true);
                    StartCoroutine(LoadNewScene("Aula3_M"));
                    //AudioManager.instance.PlayOneShot(FMODEvents.instance.openDoor, this.transform.position);
                }
                else
                {
                    Debug.Log("Trova chiave per entrare");
                    CanvasPorta3.SetActive(true);
                }
            }
            else if (_prompt == "Door-M4")
            {
                _animator.SetBool("aperto", true);
                StartCoroutine(LoadNewScene("Aula4_M"));
                //AudioManager.instance.PlayOneShot(FMODEvents.instance.openDoor, this.transform.position);
            }
            else if (_prompt == "Door-M5")
            {
                _animator.SetBool("aperto", true);
                StartCoroutine(LoadNewScene("Aula5_M"));
                //AudioManager.instance.PlayOneShot(FMODEvents.instance.openDoor, this.transform.position);
            }
            else if (_prompt == "Door-M6")
            {
                _animator.SetBool("aperto", true);
                StartCoroutine(LoadNewScene("Aula6_M"));
                //AudioManager.instance.PlayOneShot(FMODEvents.instance.openDoor, this.transform.position);
            }
            else
                Debug.Log("Hai aperto la porta!");        
        }
        AudioManager.instance.PlayOneShot(FMODEvents.instance.openDoor, this.transform.position);
        return true;
    }
    private IEnumerator LoadNewScene(string sceneName)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }

}
