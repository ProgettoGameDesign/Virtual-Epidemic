using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasActive : MonoBehaviour
{
   public Canvas canvas; // Assegna il Canvas nell'Inspector

    // Disabilita il Canvas
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        canvas.gameObject.SetActive(true);
    }

    // Abilita il Canvas
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        canvas.gameObject.SetActive(false);
    }
}
