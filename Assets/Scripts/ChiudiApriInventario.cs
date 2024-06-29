using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiudiApriInventario : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    public void SwitchActive()
    {
        canvas.SetActive(!canvas.activeSelf);

    }
}
