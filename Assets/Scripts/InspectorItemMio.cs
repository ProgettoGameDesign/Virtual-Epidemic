using System.Collections;
using System.Collections.Generic;
using CGT;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InspectorItemMio : MonoBehaviour
{
    private string nomeItem;
    private InspectObject inspectObject;
    [SerializeField] GameObject pulsanteChiudi;
    [SerializeField] GameObject pulsanteLeggi;
    public GameObject ScrollBar;
    public GameObject ScrollRect;
    public GameObject textBox;
    [SerializeField] private ChiudiApriInventario chiudiApriInventario;
    private string[] leggibili = { "Pagina1", "Pagina2", "Pagina3", "Pagina4", "Pagina_schema", "Diario" };
    public void AcquisisciNome(string nome)
    {
        nomeItem = nome;
        //Debug.Log(nomeItem);
        //IspezionaElemento();

    }
    public void IspezionaElemento()
    {
        if (nomeItem == null)
            return;
        else
        {
            chiudiApriInventario.SwitchActive();
            pulsanteChiudi.SetActive(true);

            InspectObject inspectObject = null;

            foreach (Transform child in gameObject.transform)
            {
                if (child.gameObject.name == nomeItem)
                {
                    inspectObject = child.GetComponent<InspectObject>();
                    InspectManager.instance.StartInspecting(inspectObject);

                    if (leggibili.Contains(nomeItem))
                    {
                        pulsanteLeggi.SetActive(true);
                        SetText();
                    }

                    break; 
                }
            }
            
        }
    }

    public void SetText()
    {
        bool shouldScroll = false;

        switch (nomeItem)
        {
            case "Pagina1":
                textBox.GetComponent<TextMeshProUGUI>().text = "Turin, October 22, 2023 " +
                    "\n\nI contacted Professor Nerra for my thesis project.The virtual world I intend to create requires perfect colorimetric and photorealistic reproduction.Who better than him to help me with this? I hope he responds soon.I've also contacted Professor Schiavetti, and I need things to proceed in parallel. ";
                shouldScroll = false;
                break;
            case "Pagina2":
                textBox.GetComponent<TextMeshProUGUI>().text = "Turin, November 3, 2023 " +
            "\n\nProfessor Nerra finally responded.He seems very interested in the project, thank goodness.I have an appointment in three days, and I'll show him my prototype. I'm sure he'll like it. I'll try to speed things up; Professor Schiavetti and I have already started.";
                shouldScroll = false;
                break;
            case "Pagina3":
                textBox.GetComponent<TextMeshProUGUI>().text = "Turin, November 17, 2023" +
                    "\n\nI’m already at the third meeting with the professor. Everything is going great; the visual aspect of my virtual world has improved exponentially. The professor spends hours inside it and is enthusiastic, if it weren't for his smoke breaks… I wish he could stay there all the time. He manages the visual aspect of the world in real-time, and every time he decides to take a break, the difference is immediately noticeable. How I wish I could constantly draw from his knowledge. Ah, during the last meeting, something quite strange happened. I took a second away from the headset while the professor was still working, and I'm sure I saw for a moment as if the real world had gone mad, lost its realism. I could swear I saw our world in black and white. Am I going crazy? Strange things are also happening with Professor Schiavetti, but I’ve dedicated specific recordings to those experiments, so I won’t dwell on that here. I just want to complete my project; my virtual world will be incredible!";
                shouldScroll = true;
                break;
            case "Pagina4":
                textBox.GetComponent<TextMeshProUGUI>().text = "Turin, December 7, 2023" +
                    "\n\nProfessor Nerra is starting to avoid me, but since he stopped collaborating, I've noticed a significant difference in the quality of my world. He was scared when I managed to make 3 minutes in the real world feel like 3 hours in the virtual one. Isn’t that fantastic? The only side effect is that the body in the real world loses consciousness. All primary functions obviously remain active, but it's as if you’re in a trance state. I’ll add that when the professor is connected, the episodes of visual distortion in reality keep increasing, but is it really that relevant? It’s only an effect confined to a few square meters. Nerra says it’s starting to seem dangerous. Nonsense, I think I might be creating something unique, unrepeatable. He’s just scared because he likes my virtual world too much; he’s afraid of 'getting stuck in there.' Maybe I’ll come up with a way for him to smoke in the virtual world... just kidding, he doesn’t have to worry. I know how to dispel his fears; I just need him to agree to help me one more time, just one more time.";
                shouldScroll = true;
                break;
            case "Diario":
                textBox.GetComponent<TextMeshProUGUI>().text = "Turin, December 22, 2023" +
                    "\n\nThe professor, exasperated, agreed to see me today for the last time, on the condition that he hears nothing more about it. Perfect, just before the Christmas holidays. I've already dealt with Schiavetti; I should be able to handle him too." +
                    "\n\nNic Tosto.";
                shouldScroll = false;
                break;
            case "Pagina_schema":
                textBox.GetComponent<TextMeshProUGUI>().text = "Additive synthesis" +
                    "\n\nDifferents color stimoli hit the eye in rapid succession -> get mixed!" +
                    "\n\n EX) First experiments in color cinema" +
                    "\n\n\n\n PW: BYCMRC";
                shouldScroll = false;
                break;
            default:
                textBox.GetComponent<TextMeshProUGUI>().text = "Predefinito";
                shouldScroll = false;
                break;

        }

        if (!shouldScroll)
        {
            ScrollBar.SetActive(false);
            ScrollRect.GetComponent<ScrollRect>().enabled = false;
        }
        else
        {
            ScrollBar.SetActive(true);
            ScrollRect.GetComponent<ScrollRect>().enabled = true;
        }

    }

}