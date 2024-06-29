using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabilitaPagine : MonoBehaviour
{
    [SerializeField] private SceneState sceneState;
    [SerializeField] private GameObject paginaToDisable;

    // Update is called once per frame
    void Update()
    {
        
        if(sceneState.Pagina1 == true){
            paginaToDisable.SetActive(false);
        }
        else if(sceneState.Pagina5 == true){
            paginaToDisable.SetActive(false);

        }
        else if(sceneState.Pagina2 == true){
            paginaToDisable.SetActive(false);

        }
        else if(sceneState.Pagina3 == true){
            paginaToDisable.SetActive(false);

        }
        else if(sceneState.Pagina4 == true){
            paginaToDisable.SetActive(false);

        }
        
    
    }
}
