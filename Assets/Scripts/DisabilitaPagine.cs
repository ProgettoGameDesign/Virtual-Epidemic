using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabilitaPagine : MonoBehaviour
{
    [SerializeField] private Diario diario;
    [SerializeField] private SceneState sceneState;

    // Update is called once per frame
    void Update()
    {
        if(diario.Pagina1 == true){
            GameObject foundObject = GameObject.Find("Pagina1");
            if (foundObject!=null)
                foundObject.SetActive(false);
            else
                return;
        }
        else if(diario.Pagina2 == true){
            GameObject foundObject = GameObject.Find("Pagina2");
            if (foundObject!=null)
                foundObject.SetActive(false);
            else
                return;

        }
        else if(sceneState.Pagina3 == true){
            GameObject foundObject = GameObject.Find("Pagina3");
            if (foundObject!=null)
                foundObject.SetActive(false);
            else
                return;

        }
        else if(diario.Pagina4 == true){
            GameObject foundObject = GameObject.Find("Pagina4");
            if (foundObject!=null)
            foundObject.SetActive(false);
            else
                return;

        }
        else if(diario.Pagina5 == true){
            GameObject foundObject = GameObject.Find("Pagina5");
            if (foundObject!=null)
            foundObject.SetActive(false);
            else
                return;

        }
        else if(diario.Pagina6 == true){
            GameObject foundObject = GameObject.Find("Pagina6");
            if (foundObject!=null)
            foundObject.SetActive(false);
            else
                return;

        }
    }
}
