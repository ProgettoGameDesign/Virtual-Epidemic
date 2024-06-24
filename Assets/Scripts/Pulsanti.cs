using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsanti : MonoBehaviour
{
    public string buttonValue;
    [SerializeField] private ManagerTastierino keypadManager;
    [SerializeField] private Animator animator;


    void OnMouseDown()
    {
        if (keypadManager != null)
        {
            //Debug.Log("hai premuto 1");
            keypadManager.AddDigit(buttonValue);
            animator.SetBool("premuto", true);
        }
    }
    
}
