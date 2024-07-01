using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Invoke("StartFinalCutsce", 3f);
        }
    }
    void StartFinalCutsce()
    {
        //qua va implementata la funzione per far partire l'ultima cutscene

    }
}
