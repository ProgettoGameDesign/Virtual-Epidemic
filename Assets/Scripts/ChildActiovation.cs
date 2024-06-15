using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildActiovation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Itera attraverso tutti i figli del GameObject associato a questo script
        foreach (Transform child in transform)
        {
            // Disattiva ogni GameObject figlio
            child.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // Itera attraverso tutti i figli del GameObject associato a questo script
        foreach (Transform child in transform)
        {
            // Disattiva ogni GameObject figlio
            child.gameObject.SetActive(false);
        }
    }
}
