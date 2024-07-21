using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubsScript : MonoBehaviour
{
    public GameObject textBox;

    void Start()
    {
        StartCoroutine(TheSequence());
    }

    IEnumerator TheSequence()
    {
        textBox.GetComponent<TextMeshProUGUI>().text = "Hello Inspector Gastani Frinzi";
        yield return new WaitForSeconds(2f);
        textBox.GetComponent<TextMeshProUGUI>().text = "I'm reaching out about an emergency at the Polytechnic University";
        yield return new WaitForSeconds(3.1f);
        textBox.GetComponent<TextMeshProUGUI>().text = "of Turin. An unusual epidemic linked to virtual reality headsets";
        yield return new WaitForSeconds(3.6f);
        textBox.GetComponent<TextMeshProUGUI>().text = "has left many students, professors, and staff appearing lobotomized";
        yield return new WaitForSeconds(4f);
        textBox.GetComponent<TextMeshProUGUI>().text = "The entire area is under quarantine. No one can enter or leave";
        yield return new WaitForSeconds(3.6f);
        textBox.GetComponent<TextMeshProUGUI>().text = "but we're ensuring the non-infected receive daily supplies";

        
    }
 
}
