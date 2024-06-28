using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorDisplay : MonoBehaviour
{
    private Renderer materialToChange;
    void Start()
    {
        materialToChange = GetComponent<Renderer>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(materialToChange is null)
        Debug.Log("non trova il componente");
        else 
        Debug.Log("ha un materiale");
        
    }
    public void ChangeColor(string colore)
    {
        if (colore == "B")
            materialToChange.material.color = Color.blue;
        else if (colore == "G")
            materialToChange.material.color = Color.green;
        else if (colore == "R")
            materialToChange.material.color = Color.red;
        else if (colore == "Y")
            materialToChange.material.color = Color.yellow;
        else if (colore == "C")
            materialToChange.material.color = Color.cyan;
        else if (colore == "M")
            materialToChange.material.color = Color.magenta;
        
    }
    
}
