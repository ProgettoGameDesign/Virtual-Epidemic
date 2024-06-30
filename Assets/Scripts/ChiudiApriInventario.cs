using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiudiApriInventario : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    public void SwitchActive()
    {
        Debug.Log("sta funzionando");
        canvas.SetActive(!canvas.activeSelf);

    }
}
