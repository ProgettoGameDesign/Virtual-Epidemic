using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pagine : MonoBehaviour, InteractInterface
{
    [SerializeField] private Diario diario;
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        if(_prompt == "Pagina1")
        diario.Pagina1 = true;
        if(_prompt == "Pagina2")
        diario.Pagina2 = true;
        if(_prompt == "Pagina3")
        diario.Pagina3 = true;
        if(_prompt == "Pagina4")
        diario.Pagina4 = true;
        if(_prompt == "Pagina5")
        diario.Pagina5 = true;
        if(_prompt == "Pagina6")
        diario.Pagina6 = true;
        return true;
    }
}
