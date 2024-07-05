using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDoor : MonoBehaviour
{
    private Outline _outlinescript;
    [SerializeField] private Animator animator;
    void Start()
    {
        _outlinescript = gameObject.GetComponent<Outline>();
        _outlinescript.enabled = false;
         
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
            _outlinescript.enabled = true;
        else if (other.CompareTag("Gino"))
                animator.SetBool("trigger", true);
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            _outlinescript.enabled = false;
        else return;
        
    }
}
