using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public Image characterImage;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;
    private Queue<DialogueLine> lines;

    public bool isDialogueActive = false;
    public float typingSpeed = 3f;
    public Animator _animator;
    public SceneState sceneState;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
 
        lines = new Queue<DialogueLine>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueActive = true;
        _animator.Play("show");
        lines.Clear();
        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }
        DisplayNextDialogueLine();
    }
    public void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }
        DialogueLine currentLine = lines.Dequeue();
        characterImage.sprite = currentLine._character._icon;
        characterName.name = currentLine._character._name;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine._line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        _animator.Play("hide");
        sceneState.blockMovementPlayer = false;
        //sceneState.NPCtrig1 = 2;
    }

    
}
