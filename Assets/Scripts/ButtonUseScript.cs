using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUseScript : MonoBehaviour
{
    private string nomeItem;
    [SerializeField] GameObject torch;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().interactable = false; 
        
    }
    public void AcquisisciNomeXUsa(string nome)    
    {
        nomeItem = nome;
        //Debug.Log(nomeItem);
        //IspezionaElemento();

    }
    // Update is called once per frame
    void Update()
    {
        if(nomeItem == "Telecamera")
        gameObject.GetComponent<Button>().interactable = true; 
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
            return; 
        } 

        
    }
    public void UsaOggetto()
    {
        if(nomeItem == "Telecamera")
        {
            torch.SetActive(true);

        }
        else return;
    }
}
