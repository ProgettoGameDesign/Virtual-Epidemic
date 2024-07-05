using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTastierino : MonoBehaviour
{
    public string correctSequence = "1234";
    private string currentSequence = "";
    private float timeToWait = 0.5f;
    private Outline _outlineTastierino;
    private Outline _outlineDisplay;
    [SerializeField] SceneState sceneState;
    [SerializeField] GameObject asterisco1;
    [SerializeField] GameObject asterisco2;
    [SerializeField] GameObject asterisco3;
    [SerializeField] GameObject asterisco4;
    [SerializeField] GameObject tastierinoToDisappear;
    [SerializeField] GameObject displayNumeri;
    [SerializeField] Animator animator;
    public void AddDigit(string digit)
    {
        currentSequence += digit;
        //displayText.text = currentSequence;
        CheckSequence();
    }
    private void CheckSequence()
    {
        if (currentSequence.Length == correctSequence.Length)
        {
            if (currentSequence == correctSequence)
            {
                sceneState.blockMovementPlayer = false;
                gameObject.layer = 0;
                _outlineTastierino.OutlineColor = Color.green;
                _outlineTastierino.enabled = true;
                _outlineDisplay.OutlineColor = Color.green;
                _outlineDisplay.enabled = true;
                Cursor.visible = false;
                animator.Play("hide");
                StartCoroutine(SequenzaGiusta());
                
                
                
            }
            else
            {
                _outlineTastierino.OutlineColor = Color.red;
                _outlineTastierino.enabled = true;
                _outlineDisplay.OutlineColor = Color.red;
                _outlineDisplay.enabled = true;
                StartCoroutine(SequenzaSbagliata());
                Debug.Log("Sequenza sbagliata! Ripristino.");
                // Resetta la sequenza
                
                //displayText.text = currentSequence;
            }
        }
    }
    private IEnumerator SequenzaGiusta()
    {
        yield return new WaitForSeconds(timeToWait+1);
        gameObject.GetComponent<LightDoor>().enabled = false;
        tastierinoToDisappear.SetActive(false);
        
        sceneState.tastierino = true;


    }
    private IEnumerator SequenzaSbagliata()
    {
        yield return new WaitForSeconds(timeToWait);
        _outlineTastierino.enabled = false;
        _outlineDisplay.enabled = false;
        currentSequence = "";
        asterisco1.SetActive(false);
        asterisco2.SetActive(false);
        asterisco3.SetActive(false);
        asterisco4.SetActive(false);

    }
    void Start()
    {
        _outlineTastierino = tastierinoToDisappear.GetComponent<Outline>();
        _outlineTastierino.enabled = false;
        _outlineDisplay = displayNumeri.GetComponent<Outline>();
        _outlineDisplay.enabled = false;

    }
    void Update()    
    {
        if(currentSequence.Length == 1)
        {
            asterisco1.SetActive(true);
        }
        if(currentSequence.Length == 2)
        {
            asterisco2.SetActive(true);
        }
        if(currentSequence.Length == 3)
        {
            asterisco3.SetActive(true);
        }
        if(currentSequence.Length == 4)
        {
            asterisco4.SetActive(true);
        }
        
        if(sceneState.tastierino)  
        {
            gameObject.GetComponent<LightDoor>().enabled = false;
            gameObject.layer = 0;

        }

    }
}
