using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

public class StartConversation : MonoBehaviour
{
    [SerializeField] TPM_characterController playerController;
    [SerializeField] NPCConversation _npcconversation;
    [SerializeField] private Transform player; // Riferimento al giocatore
    [SerializeField] private Transform NPC; // Transform dell'NPC
    [SerializeField] private float NPCspeed = 4f; // Velocità di movimento
    [SerializeField] Animator _NPCanimator;
    private float stopDistance = 3f; // Distanza minima dal giocatore
    private bool NPCtrig = false;
    private void OnTriggerEnter(Collider other)
    {
        NPCtrig = true;
        _NPCanimator.SetBool("trigger", true);
        playerController._canmove = false;
        playerController._inputSpeed = 0;
        StartCoroutine(StartDialogue());
    }
    void Update()
    {
        if(NPCtrig)
        {
            NpcApproaching();
            
        }
        if(ConversationManager.Instance.IsConversationActive)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log(ConversationManager.Instance.GetInt("dialogueLine"));
                ConversationManager.Instance.SetInt("dialogueLine", ConversationManager.Instance.GetInt("dialogueLine")+1);

            }
        }
    }
    private IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(1);
        ConversationManager.Instance.StartConversation(_npcconversation);
    }
    void  NpcApproaching()
    {
        
        // Calcola la direzione verso il giocatore
        Vector3 direction = player.position - NPC.position;
        direction.y = 0; // Mantieni il movimento sul piano orizzontale

        // Ruota l'oggetto per rivolgersi verso il giocatore
        NPC.LookAt(new Vector3(player.position.x, NPC.position.y, player.position.z));
        
        // Controlla la distanza dal giocatore
        if (direction.magnitude > stopDistance)
        {
            Debug.Log("ancora non raggiunto");
            // Normalizza la direzione e calcola il nuovo punto
            Vector3 moveDirection = direction.normalized;
            Vector3 targetPosition = player.position - moveDirection * stopDistance;

            // Sposta l'oggetto verso il target
            NPC.position = Vector3.MoveTowards(NPC.position, targetPosition, NPCspeed * Time.deltaTime);
        }
        else _NPCanimator.SetBool("trigger", false);
        
    }
    
void OnDialogueEnd()
    {
        playerController._canmove = true;
    }

}
