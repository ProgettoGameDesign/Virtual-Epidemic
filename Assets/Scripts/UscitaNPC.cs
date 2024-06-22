using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UscitaNPC : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] GameObject NPC;
    void OnTriggerEnter(Collider other)  
    {
        if(other.CompareTag("Gino"))
            _animator.SetBool("trigger", true);

    }
    void OnTriggerExit(Collider other)  
    {
        if(other.CompareTag("Gino"))
        NPC.SetActive(false);

    }
}
