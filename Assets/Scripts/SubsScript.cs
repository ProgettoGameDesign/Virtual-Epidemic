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
        yield return new WaitForSeconds(3.33f);
        textBox.GetComponent<TextMeshProUGUI>().text = "Hello Inspector Gastani Frinzi";
        yield return new WaitForSeconds(1.71f);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(0.23f);
        textBox.GetComponent<TextMeshProUGUI>().text = "I'm reaching out about an emergency at the Polytechnic University";
        yield return new WaitForSeconds(2.83f);
        textBox.GetComponent<TextMeshProUGUI>().text = "of Turin. An unusual epidemic linked to virtual reality headsets";
        yield return new WaitForSeconds(4.2f);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(0.13f);
        textBox.GetComponent<TextMeshProUGUI>().text = "has left many students, professors, and staff appearing lobotomized";
        yield return new WaitForSeconds(4f);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(0.23f);
        textBox.GetComponent<TextMeshProUGUI>().text = "The entire area is under quarantine. No one can enter or leave";
        yield return new WaitForSeconds(3.9f);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(0.33f);
        textBox.GetComponent<TextMeshProUGUI>().text = "but we're ensuring the non-infected receive daily supplies";
        yield return new WaitForSeconds(2.93f);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(0.47f);
        textBox.GetComponent<TextMeshProUGUI>().text = "Families have been reassured this is temporary";
        yield return new WaitForSeconds(2.43f);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(0.17f);
        textBox.GetComponent<TextMeshProUGUI>().text = "without revealing the true nature of the quarantine";
        yield return new WaitForSeconds(2.43f);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(0.63f);
        textBox.GetComponent<TextMeshProUGUI>().text = "Inside the Polytechnic, we have Professor Scottino";
        yield return new WaitForSeconds(2.87f);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(0.43f);
        textBox.GetComponent<TextMeshProUGUI>().text = "a virtual reality expert, who offered to find a solution";
        yield return new WaitForSeconds(2.87f);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(0.67f);
        textBox.GetComponent<TextMeshProUGUI>().text = "We gave him five days, after which we'll have to go public with the case";
        yield return new WaitForSeconds(3.73f);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(0.6f);
        textBox.GetComponent<TextMeshProUGUI>().text = "Unfortunately, we haven't heard from him for two days";
        yield return new WaitForSeconds(2.53f);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(0.4f);
        textBox.GetComponent<TextMeshProUGUI>().text = "and the deadline is tomorrow at midnight.";
        yield return new WaitForSeconds(2.3f);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(0.93f);
        textBox.GetComponent<TextMeshProUGUI>().text = "We urgently need you to investigate";
        yield return new WaitForSeconds(2.2f);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(0.33f);
        textBox.GetComponent<TextMeshProUGUI>().text = "find Professor Scottino";
        yield return new WaitForSeconds(1.67f);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(0.67f);
        textBox.GetComponent<TextMeshProUGUI>().text = "and see if he has found a cure.";
        yield return new WaitForSeconds(1.9f);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(0.97f);
        textBox.GetComponent<TextMeshProUGUI>().text = "You'll get a badge to pass through the quarantine zone";
        yield return new WaitForSeconds(2.43f);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(0.7f);
        textBox.GetComponent<TextMeshProUGUI>().text = "This is a very delicate situation";
        yield return new WaitForSeconds(2.23f);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(0.27f);
        textBox.GetComponent<TextMeshProUGUI>().text = "so please proceed with extreme caution.";
        yield return new WaitForSeconds(2.33f);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(0.8f);
        textBox.GetComponent<TextMeshProUGUI>().text = "I wish you good luck, Inspector";
        yield return new WaitForSeconds(1.53f);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(0.47f);
        textBox.GetComponent<TextMeshProUGUI>().text = "Our fate is in your hands.";
        yield return new WaitForSeconds(1.47f);

    }
 
}
