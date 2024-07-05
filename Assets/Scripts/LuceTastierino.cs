using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuceTastierino : MonoBehaviour
{
    [SerializeField] SceneState sceneState;

    // Update is called once per frame
    void Update()
    {
        if (sceneState._lightup)
        gameObject.SetActive(false);
        
    }
}
