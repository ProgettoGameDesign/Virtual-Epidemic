using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateState : MonoBehaviour
{
    [SerializeField] private GameObject _NPC;
    [SerializeField] SceneState sceneState;

    void Awake()
    {
        if(sceneState.NPCtrig1 == 3)
        {
            Destroy(_NPC);
        }
    }

}
