using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterNavController : MonoBehaviour
{
    [SerializeField] private Transform player; // Riferimento al giocatore
    [SerializeField] private Transform escape; // Riferimento al punto di fuga
    [SerializeField] Animator _NPCanimator; // Animator del NPC
    [SerializeField] SceneState sceneState;

    //[SerializeField] private Camera _camera;
    //[SerializeField] private GameObject _targetFeedback;

    private NavMeshAgent _navMeshAgent;
    private float stopDistance = 2.5f;
    public float rotationSpeed = 50.0f;

    
    void Start ()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
	}
    /*
    void Update()
    {
        _navMeshAgent.destination = player.position; 
    }*/
    public void NpcApproaching()
    {
        if (player != null)
        {
            // Calcolare la distanza attuale dal target
            float distanceToTarget = Vector3.Distance(transform.position, player.position);

            // Se la distanza è maggiore della stopDistance, continuare a muoversi verso il target
            if (distanceToTarget > stopDistance)
            {
                _navMeshAgent.SetDestination(player.position);
                //RotateTowards(player);
                
            }
            else
            {
                // Fermare il movimento se siamo abbastanza vicini
                _navMeshAgent.ResetPath();
                _NPCanimator.SetBool("trigger", false);
            }
        }


    }
    public void NpcEscape()
    {
        if (escape != null)
        {
            // Calcolare la distanza attuale dal target
            float distanceToTarget = Vector3.Distance(transform.position, escape.position);

            // Se la distanza è maggiore della stopDistance, continuare a muoversi verso il target
            if (distanceToTarget > stopDistance)
            {
                _navMeshAgent.SetDestination(escape.position);
                //RotateTowards(escape);
            }
            else
            {
                // Fermare il movimento se siamo abbastanza vicini
                _navMeshAgent.ResetPath();
                _NPCanimator.SetBool("trigger", false);
                gameObject.SetActive(false);
                sceneState.NPCtrig1 = 3;
            }
        }
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
