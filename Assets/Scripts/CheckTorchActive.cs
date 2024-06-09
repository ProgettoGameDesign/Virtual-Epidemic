using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTorchActive : MonoBehaviour
{
    [SerializeField] private SceneState playerData;
    private bool _active = false;

    // Update is called once per frame
    void Update()
    {
        if (_active == false)       
        {
            if(playerData._torchActive)
                {
                    foreach (Transform child in transform)
                    {
                        // Confronta il nome del GameObject figlio con il prompt
                        if (child.gameObject.name == "Torcia")
                        {
                            child.gameObject.SetActive(true);
                            _active = true;
                        }
                    }
                }
        }
        else 
        return;
    }
}
