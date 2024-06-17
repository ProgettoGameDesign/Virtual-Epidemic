using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueCharacter
{
    public string _name;
    public Sprite _icon;
}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter _character;
    [TextArea(3,10)]
    public string _line;
}
[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

public class DialogueClass : MonoBehaviour
{
    [SerializeField] private Transform player; // Riferimento al giocatore
    [SerializeField] private Transform escape; // Riferimento al punto di fuga
    [SerializeField] private Transform NPC; // Transform dell'NPC
    [SerializeField] private float NPCspeed = 4f; // Velocità di movimento
    [SerializeField] Animator _NPCanimator;
    private float stopDistance = 2.5f;
    public int NPCtrig = 0;
    public Dialogue dialogue;
    void OnTriggerEnter(Collider other)
    {
        NPCtrig = 1;
        _NPCanimator.SetBool("trigger", true);
        StartCoroutine(TriggerDialogue());
    }
    void Update()
    {
        if(NPCtrig==1)
        {
            NpcApproaching();            
        }
        if(NPCtrig == 2)
        {
             _NPCanimator.SetBool("trigger", true);
            NpcEscape();            
        }
        if(DialogueManager.Instance.isDialogueActive)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                //Debug.Log("manda avanti il dialogo");
                DialogueManager.Instance.DisplayNextDialogueLine();

            }
        }
    }
    private IEnumerator TriggerDialogue()
    {
        yield return new WaitForSeconds(1);
        DialogueManager.Instance.StartDialogue(dialogue);
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
        else
        {
            _NPCanimator.SetBool("trigger", false);
            
        }
        
    }
    public void NpcEscape()
    {
        // Calcola la direzione verso il giocatore
        Vector3 direction = escape.position - NPC.position;
        direction.y = 0; // Mantieni il movimento sul piano orizzontale

        // Ruota l'oggetto per rivolgersi verso il giocatore
        NPC.LookAt(new Vector3(escape.position.x, NPC.position.y, escape.position.z));
        
        // Controlla la distanza dal giocatore
        if (direction.magnitude > stopDistance)
        {
            Debug.Log("ancora non raggiunto");
            // Normalizza la direzione e calcola il nuovo punto
            Vector3 moveDirection = direction.normalized;
            Vector3 targetPosition = escape.position - moveDirection * stopDistance;

            // Sposta l'oggetto verso il target
            NPC.position = Vector3.MoveTowards(NPC.position, targetPosition, NPCspeed * Time.deltaTime);
        }
        else _NPCanimator.SetBool("trigger", false);
    }


}
    