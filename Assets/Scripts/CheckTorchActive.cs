using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTorchActive : MonoBehaviour
{
    [SerializeField] private SceneState playerData;
    [SerializeField] private GameObject _torciaCamera;
    private bool _active = false;

    // Update is called once per frame
    void Update()
    {
        if(playerData._torchActive)
        {
            _torciaCamera.SetActive(true);
        }
        else
        {
            _torciaCamera.SetActive(false);
        }
    }
}
