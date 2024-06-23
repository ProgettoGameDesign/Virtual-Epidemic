using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTastierino : MonoBehaviour
{
    public string correctSequence = "1234";
    private string currentSequence = "";
    private float timeToWait = 0.5f;
    [SerializeField] SceneState sceneState;
    [SerializeField] GameObject asterisco1;
    [SerializeField] GameObject asterisco2;
    [SerializeField] GameObject asterisco3;
    [SerializeField] GameObject asterisco4;
    [SerializeField] GameObject tastierinoToDisappear;
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
                StartCoroutine(SequenzaGiusta());
                Debug.Log("Sequenza corretta! La porta si apre.");
                //currentSequence = "";
                
                //sceneState.tastierino = true;
                
            }
            else
            {
                StartCoroutine(SequenzaSbagliata());
                Debug.Log("Sequenza sbagliata! Ripristino.");
                // Resetta la sequenza
                
                //displayText.text = currentSequence;
            }
        }
    }
    private IEnumerator SequenzaGiusta()
    {
        yield return new WaitForSeconds(timeToWait);
        tastierinoToDisappear.SetActive(false);
        
        sceneState.tastierino = true;


    }
    private IEnumerator SequenzaSbagliata()
    {
        yield return new WaitForSeconds(timeToWait);
        currentSequence = "";
        asterisco1.SetActive(false);
        asterisco2.SetActive(false);
        asterisco3.SetActive(false);
        asterisco4.SetActive(false);

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
