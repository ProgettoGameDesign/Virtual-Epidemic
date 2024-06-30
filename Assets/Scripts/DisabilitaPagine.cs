using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabilitaPagine : MonoBehaviour
{
    [SerializeField] private SceneState sceneState;
    [SerializeField] private GameObject paginaToDisable;

    // Update is called once per frame
    void Start()
    {
        
        if(sceneState.Pagina1 == true){
            Disabilita("Pagina1");
        }
        if(sceneState.Pagina5 == true){
            Disabilita("Pagina_schema");

        }
        if(sceneState.Pagina2 == true){
            Disabilita("Pagina2");

        }
        if(sceneState.Pagina3 == true){
            Disabilita("Pagina3");

        }
        if(sceneState.Pagina4 == true){
            Disabilita("Pagina4");

        }
        
    
    }
    void Disabilita(string nome)
    {
        GameObject obj = GameObject.Find(nome);
        
        if (obj != null)
        {
            Debug.Log("trovato");
            obj.SetActive(false);
        }
        else
        Debug.Log("non trovato");
    }
}
