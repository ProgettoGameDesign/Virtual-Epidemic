using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SceneState : ScriptableObject
{
    public Vector3 lastPosition_AI = new Vector3(0,0,0);
    public Vector3 lastPosition_CorridoioM = new Vector3(0,0,0);
    public bool _torchActive;
    public bool _hasKey;
    public bool _lightup;
    public Color _currentcolor;
    public int stateOfCutscene1;
    public bool NerraCutscene;
    public bool tastierino;
    public bool tastierinoServetti;
    public bool blockMovementPlayer;
    public bool Pagina1;
    public bool Pagina2;
    public bool Pagina3;
    public bool Pagina4;
    public bool Pagina5;
    public Color _ambient;
    public void ResetData() // imposta ai valori iniziali ogni volta che fa ripartire il gioco
    {
        lastPosition_AI = Vector3.zero; 
        lastPosition_CorridoioM = Vector3.zero;
        _torchActive = false;
        _hasKey = false;
        _lightup = false;
        _ambient = Color.black;
        _currentcolor = Color.white;
        stateOfCutscene1 = 1;
        NerraCutscene = false;
        tastierino = false;
        tastierinoServetti = false;
        blockMovementPlayer = false;
        Pagina1 = false;
        Pagina2 = false;
        Pagina3 = false;
        Pagina4 = false;
        Pagina5 = false;
    }
}
