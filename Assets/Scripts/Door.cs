using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door : MonoBehaviour, InteractInterface
{
    [SerializeField] private string _prompt;
    [SerializeField] Animator _animator;
    [SerializeField] private GameObject CanvasPorta3;
    [SerializeField] private GameObject _canvasFadeToBlack;
    public string InteractionPrompt => _prompt;
    //private Vector3 _spawnPosition;
    public SceneState _sceneState;
    public GameObject virtualCamera;
    private float rotationSpeed = 0.6f;

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
                _sceneState.blockMovementPlayer = true;
                _animator.SetBool("aperto", true);
                if (SceneManager.GetActiveScene().name == "Ambiente iniziale") 
                {
                    StartCoroutine(RotateCamera());
                    _canvasFadeToBlack.SetActive(true);
                }
                else StartCoroutine(LoadNewScene("Corridoio_M"));

                //AudioManager.instance.PlayOneShot(FMODEvents.instance.openDoor, this.transform.position);
            }
            else if (_prompt == "Door-M1")
            {
                _sceneState.blockMovementPlayer = true;
                _animator.SetBool("aperto", true);
                StartCoroutine(LoadNewScene("Aula1_M"));
                //AudioManager.instance.PlayOneShot(FMODEvents.instance.openDoor, this.transform.position);
            }
            else if (_prompt == "Door-M2")
            {
                _sceneState.blockMovementPlayer = true;
                _animator.SetBool("aperto", true);
                StartCoroutine(LoadNewScene("Aula2_M"));
                //AudioManager.instance.PlayOneShot(FMODEvents.instance.openDoor, this.transform.position);
            }
            else if (_prompt == "Door-M3")
            {
                if (_sceneState._hasKey == true)

                {
                    Button button = CanvasPorta3.GetComponentInChildren<Button>();
                    button.GetComponentInChildren<TextMeshProUGUI>().text = "Used Key";
                    CanvasPorta3.SetActive(true);
                    _sceneState.blockMovementPlayer = true;
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
                _sceneState.blockMovementPlayer = true;
                _animator.SetBool("aperto", true);
                StartCoroutine(LoadNewScene("Aula4_M"));
                //AudioManager.instance.PlayOneShot(FMODEvents.instance.openDoor, this.transform.position);
            }
            else if (_prompt == "Door-M5")
            {
                _sceneState.blockMovementPlayer = true;
                _animator.SetBool("aperto", true);
                StartCoroutine(LoadNewScene("Aula5_M"));
                //AudioManager.instance.PlayOneShot(FMODEvents.instance.openDoor, this.transform.position);
            }
            else if (_prompt == "Door-M6")
            {
                _sceneState.blockMovementPlayer = true;
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
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(sceneName);
        _sceneState.blockMovementPlayer = false;
    }
    IEnumerator RotateCamera()
    {
        Quaternion initialRotation = virtualCamera.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(20, -90, 0);
        float elapsedTime = 0f;
        CinemachineVirtualCamera cameraComponent = virtualCamera.GetComponent<CinemachineVirtualCamera>();
        //cameraComponent.Follow = _nuovoTarget;
        float startFOV = cameraComponent.m_Lens.FieldOfView;
        float targetFOV = 22;

        while (elapsedTime < 1.8f)
        {
            virtualCamera.transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime * rotationSpeed);
            cameraComponent.m_Lens.FieldOfView = Mathf.Lerp(startFOV, targetFOV, elapsedTime / 1.8f);
            elapsedTime += Time.deltaTime;
            yield return null;
        } 

        virtualCamera.transform.rotation = targetRotation; // Assicurati che la rotazione finale sia esattamente quella target
        SceneManager.LoadScene("Corridoio_M");
        _sceneState.blockMovementPlayer = false;
    }
    private void PlaySound(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);
    }

}
