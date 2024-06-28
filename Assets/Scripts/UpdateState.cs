using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateState : MonoBehaviour
{
    [SerializeField] private GameObject _NPC;
    [SerializeField] private GameObject _porta;
    [SerializeField] private SceneState sceneState;
    [SerializeField] private BoxCollider colliderConversazione;

    void Awake()
    {
        if(sceneState.stateOfCutscene1 == 3)
        {
            Destroy(_NPC);
            colliderConversazione.enabled = false;
        }
    }
    void Update()
    {
        if(sceneState.tastierinoServetti)
        {
            _porta.layer = 7;

        }
    }
}
