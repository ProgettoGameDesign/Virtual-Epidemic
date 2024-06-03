using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDoor : MonoBehaviour
{
    private Outline _outlinescript;
    void Start()
    {
        _outlinescript = gameObject.GetComponent<Outline>();
        _outlinescript.enabled = false;
         
    }
    private void OnTriggerEnter(Collider other)
    {
        _outlinescript.enabled = true;
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        _outlinescript.enabled = false;
        
    }
}
