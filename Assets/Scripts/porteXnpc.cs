using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porteXnpc : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("1");
        if(other.CompareTag("Gino"))
        {
            Debug.Log("triggerato");
            animator.SetBool("trigger", true);

        }

        
    }
}
    
