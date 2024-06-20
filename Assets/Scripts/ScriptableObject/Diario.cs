using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Diario : ScriptableObject
{
    public bool Pagina1;
    public bool Pagina2;
    public bool Pagina3;
    public bool Pagina4;
    public bool Pagina5;
    public bool Pagina6;
    public void ResetData() // imposta ai valori iniziali ogni volta che fa ripartire il gioco
    {
        Pagina1 = false;
        Pagina2 = false;
        Pagina3 = false;
        Pagina4 = false;
        Pagina5 = false;
        Pagina6 = false;
    }
    
}
