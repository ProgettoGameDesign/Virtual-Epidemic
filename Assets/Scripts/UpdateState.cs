using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateState : MonoBehaviour
{
    [SerializeField] private GameObject _NPC;
    [SerializeField] private GameObject _porta;
    [SerializeField] private SceneState sceneState;
    [SerializeField] private BoxCollider colliderConversazione;
    [SerializeField] private GameObject dissolvenzaIniziale;
    [SerializeField] Animator animatorPorta1;
    [SerializeField] Animator animatorPorta2;

    void Awake()
    {
        if(sceneState.stateOfCutscene1 == 3)
        {
            Destroy(_NPC);
            colliderConversazione.enabled = false;
        }
        if(sceneState.stateOfCutscene1 == 1)
        {
            dissolvenzaIniziale.SetActive(true);
        }
    }
    void Update()
    {
        if(sceneState.tastierinoServetti)
        {
            _porta.layer = 7;
            animatorPorta1.SetBool("endgame", true);
            animatorPorta2.SetBool("endgame", true);
            Invoke("StartFinalCutsce", 2f);
        }
    }
    void StartFinalCutsce()
    {
        SceneManager.LoadScene("Scena_Outro");

    }
}
