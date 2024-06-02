using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDoor : MonoBehaviour
{
    //public int materialIndexToDisable = 1;
    private Renderer objectRenderer;
    private Material[] listMaterials;
    private Material swapMaterial;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        //objectRenderer.materials[materialIndexToDisable] = null;
        if (objectRenderer != null) listMaterials = objectRenderer.materials;
         
    }
    private void OnTriggerEnter(Collider other)
    {
        swapMaterial = listMaterials[0];
        listMaterials[0] = listMaterials[2];
        listMaterials[2] = swapMaterial;
        
    }

    private void OnTriggerExit(Collider other)
    {
        swapMaterial = listMaterials[0];
        listMaterials[0] = listMaterials[2];
        listMaterials[2] = swapMaterial;
        
    }
}
