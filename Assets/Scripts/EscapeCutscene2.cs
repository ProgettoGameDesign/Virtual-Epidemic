using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeCutscene2 : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Transform _escapepoint;
    [SerializeField] CharacterController characterController;
    private bool escapetrigger = false;
    private float rotationSpeed = 5.0f;
    private float stopDistance = 2.0f;
    private float NPCspeed = 6f;
    private float waitTime = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(escapetrigger)
        {
            RotateTowards(_escapepoint);

            Vector3 direction = _escapepoint.position - transform.position;
            direction.y = 0; // Mantieni il movimento sul piano orizzontale

            if (direction.magnitude > stopDistance)
            {
            // Normalizza la direzione e calcola il nuovo punto
            Vector3 moveDirection = direction.normalized * NPCspeed * Time.deltaTime;
            //Vector3 targetPosition = player.position - moveDirection * stopDistance;

            // Sposta l'oggetto verso il target
            characterController.Move(moveDirection);
            }
        }
        else
        {
            if(animator.GetBool("trigger"))
                StartCoroutine(IniziaCorsa());    
        }
        
    }
    private IEnumerator IniziaCorsa()
    {
        yield return new WaitForSeconds(waitTime);
        escapetrigger = true;
    }
    void RotateTowards(Transform target)
    {
        // Calcolare la direzione verso il target
        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0; // Mantenere l'agente sul piano orizzontale

        // Calcolare la rotazione desiderata
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        // Ruotare gradualmente verso la direzione desiderata
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }
}
    
