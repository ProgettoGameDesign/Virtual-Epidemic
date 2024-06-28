using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_porta_aula3 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject canvas;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            canvas.SetActive(false);
        else return;

    }
}
