using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightObject : MonoBehaviour
{
    private Outline _outlinescript;
    // Start is called before the first frame update
    void Start()
    {
        _outlinescript = gameObject.GetComponent<Outline>();
        _outlinescript.enabled = false;  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _outlinescript.enabled = true;       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            _outlinescript.enabled = false;       
    }
}
