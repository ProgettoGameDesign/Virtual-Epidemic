using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerraSveglio : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Transform target;
    private float rotationSpeed = 3f;
    /*
    void Awake()
    {
        animator.SetBool("trigger", true);
    }*/
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DialogueManager.Instance.isDialogueActive)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                //Debug.Log("manda avanti il dialogo");
                DialogueManager.Instance.DisplayNextDialogueLine();

            }
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("breathing"))
        {
            RotateTowards(target);
        }
        
    }
    void RotateTowards(Transform target)
    {
        Vector3 direction = target.position - transform.position; // Direzione verso il target
        direction.y = 0; // Mantieni la rotazione solo sull'asse y

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
