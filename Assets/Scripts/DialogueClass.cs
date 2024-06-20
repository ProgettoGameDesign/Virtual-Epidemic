using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    //[SerializeField] private Transform player; // Riferimento al giocatore
    //[SerializeField] private Transform escape; // Riferimento al punto di fuga
    //[SerializeField] private GameObject NPC; // Transform dell'NPC
    [SerializeField] Animator _NPCanimator;
    [SerializeField] SceneState sceneState;
    [SerializeField] CharacterNavController characterNavController;
    //private float stopDistance = 2.5f;
    //private CharacterController characterController;
    //public int NPCtrig = 0;
    public Dialogue dialogue;
    void OnTriggerEnter(Collider other)
    {
        if(sceneState.NPCtrig1 == 0 )
        {
            if(!other.CompareTag("Gino"))
            {
            sceneState.NPCtrig1 = 1;
            _NPCanimator.SetBool("trigger", true);
            StartCoroutine(TriggerDialogue());
            }
        }
    }
    void Update()
    {
        if(sceneState.NPCtrig1==1)
        {
            characterNavController.NpcApproaching();           
        }
        if(sceneState.NPCtrig1 == 2)
        {
             _NPCanimator.SetBool("trigger", true);
            characterNavController.NpcEscape();            
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
        yield return new WaitForSeconds(3);
        DialogueManager.Instance.StartDialogue(dialogue);
    }
    
    /*
    void  NpcApproaching()
    {
        
        // Calcola la direzione verso il giocatore
        Vector3 direction = player.position - NPC.transform.position;
        direction.y = 0; // Mantieni il movimento sul piano orizzontale

        // Ruota l'oggetto per rivolgersi verso il giocatore
        //NPC.LookAt(new Vector3(player.position.x, NPC.transform.position.y, player.position.z));
        
        // Controlla la distanza dal giocatore
        if (direction.magnitude > stopDistance)
        {
            Debug.Log("ancora non raggiunto");
            // Ruotare gradualmente verso la direzione desiderata
             Quaternion targetRotation = Quaternion.LookRotation(direction);
            NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            // Normalizza la direzione e calcola il nuovo punto
            Vector3 moveDirection = direction.normalized * NPCspeed * Time.deltaTime;
            //Vector3 targetPosition = player.position - moveDirection * stopDistance;

            // Sposta l'oggetto verso il target
           characterController.Move(moveDirection);
        }
        else
        {
            _NPCanimator.SetBool("trigger", false);
            
        }
        
    }
    public void NpcEscape()
    {
        // Calcola la direzione verso il giocatore
        Vector3 direction = escape.position - NPC.transform.position;
        direction.y = 0; // Mantieni il movimento sul piano orizzontale

        // Ruota l'oggetto per rivolgersi verso il giocatore
        //NPC.LookAt(new Vector3(player.position.x, NPC.transform.position.y, player.position.z));
        
        // Controlla la distanza dal giocatore
        if (direction.magnitude > stopDistance)
        {
            Debug.Log("ancora non raggiunto");
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            // Normalizza la direzione e calcola il nuovo punto
            Vector3 moveDirection = direction.normalized * NPCspeed * Time.deltaTime;
            //Vector3 targetPosition = player.position - moveDirection * stopDistance;

            // Sposta l'oggetto verso il target
           characterController.Move(moveDirection);
        }
        else
        {
            _NPCanimator.SetBool("trigger", false);
            NPC.SetActive(false);
            sceneState.NPCtrig1 = 3;
            
        }
    }
    */

}
    