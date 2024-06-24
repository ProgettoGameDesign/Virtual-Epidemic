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
    
    

}
    