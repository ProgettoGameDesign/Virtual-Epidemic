using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avanzamento_dialoghi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.Instance.isDialogueActive)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                DialogueManager.Instance.DisplayNextDialogueLine();
            }
        }
        
    }
}
