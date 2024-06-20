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
    public int NPCtrig1;
    public void ResetData() // imposta ai valori iniziali ogni volta che fa ripartire il gioco
    {
        lastPosition_AI = Vector3.zero; 
        lastPosition_CorridoioM = Vector3.zero;
        _torchActive = false;
        _hasKey = false;
        _lightup = false;
        _currentcolor = Color.white;
        NPCtrig1 = 0;
    }
}
