using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] private Transform _torch;
    [SerializeField] SceneState sceneState;
    private Light _color;

    // Start is called before the first frame update
    void Start()
    {
        _color = _torch.GetComponent<Light>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _color.color = sceneState._currentcolor;
        if (Input.GetKey(KeyCode.Alpha1)) 
        {
            sceneState._currentcolor = Color.blue; 
        }
        if (Input.GetKey(KeyCode.Alpha2)) 
        {
            sceneState._currentcolor = Color.green;  
        }
        if (Input.GetKey(KeyCode.Alpha3)) 
        {
            sceneState._currentcolor = Color.red;  
        }
        if (Input.GetKey(KeyCode.Alpha0)) 
        {
            sceneState._currentcolor = Color.white;  
        }
    }
}
